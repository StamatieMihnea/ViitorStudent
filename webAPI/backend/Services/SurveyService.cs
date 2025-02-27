﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContext;
using backend.Entities;
using backend.IServices;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly DbCon _dbCon;
        private readonly IMapper _mapper;
        private readonly ILoginService _loginService;

        public SurveyService(DbCon dbCon, IMapper mapper, ILoginService loginService)
        {
            _dbCon = dbCon;
            _mapper = mapper;
            _loginService = loginService;
        }

        private static List<UserCity> CreateUserCities(SurveyModel survey)
        {
            var userCities = new List<UserCity>();
            foreach (var cityId in survey.CityIds)
            {
                userCities.Add(new UserCity() {city_id = cityId, user_id = survey.UserId});
            }

            return userCities;
        }

        private static List<UserJob> CreateUserJobs(SurveyModel survey)
        {
            return survey.JobIds.Select(jobId => new UserJob() {job_id = jobId, user_id = survey.UserId}).ToList();
        }

        private static List<UserInterest> CreateUserInterests(SurveyModel survey)
        {
            return survey.InterestIds
                .Select(interestId => new UserInterest() {interest_id = interestId, user_id = survey.UserId}).ToList();
        }

        private static List<UserClub> CreateUserClubs(SurveyModel survey)
        {
            return survey.ClubIds.Select(clubId => new UserClub() {club_id = clubId, user_id = survey.UserId}).ToList();
        }

        private static List<UserSubject> CreateUserSubjects(SurveyModel survey)
        {
            return survey.SubjectIds
                .Select(subjectId => new UserSubject() {subject_id = subjectId, user_id = survey.UserId}).ToList();
        }

        public async Task<string> DeleteSurvey(string username)
        {
            var exists = false;
            var currentUser = await _loginService.GetUser(username);
            var cities = _dbCon.Set<UserCity>().Where(o => o.user_id == currentUser.user_id);
            var jobs = _dbCon.Set<UserJob>().Where(o => o.user_id == currentUser.user_id);
            var interests = _dbCon.Set<UserInterest>().Where(o => o.user_id == currentUser.user_id);
            var subjects = _dbCon.Set<UserSubject>().Where(o => o.user_id == currentUser.user_id);
            var clubs = _dbCon.Set<UserClub>().Where(o => o.user_id == currentUser.user_id);

            if (await cities.AnyAsync())
            {
                _dbCon.Set<UserCity>().RemoveRange(cities);
                exists = true;
            }

            if (await jobs.AnyAsync())
            {
                _dbCon.Set<UserJob>().RemoveRange(jobs);
                exists = true;
            }

            if (await interests.AnyAsync())
            {
                _dbCon.Set<UserInterest>().RemoveRange(interests);
                exists = true;
            }

            if (await subjects.AnyAsync())
            {
                _dbCon.Set<UserSubject>().RemoveRange(subjects);
                exists = true;
            }

            if (await cities.AnyAsync())
            {
                _dbCon.Set<UserClub>().RemoveRange(clubs);
                exists = true;
            }

            if (exists)
            {
                await _dbCon.SaveChangesAsync();
                return "Done";
            }
            else
            {
                return "None";
            }
        }

        public async Task<SurveyModel> AddSurveyToUser(SurveyModel survey)
        {
            await _dbCon.UserCity.AddRangeAsync(CreateUserCities(survey));
            await _dbCon.UserJob.AddRangeAsync(CreateUserJobs(survey));
            await _dbCon.UserInterest.AddRangeAsync(CreateUserInterests(survey));
            await _dbCon.UserClub.AddRangeAsync(CreateUserClubs(survey));
            await _dbCon.UserSubject.AddRangeAsync(CreateUserSubjects(survey));
            await _dbCon.SaveChangesAsync();
            return survey;
        }

        public async Task<List<CityModel>> GetCities()
        {
            return _mapper.Map<List<CityModel>>(await _dbCon.Set<City>().OrderBy(c => c.city_id).ToListAsync());
        }

        public async Task<List<ClubModel>> GetClubs()
        {
            return _mapper.Map<List<ClubModel>>(await _dbCon.Set<Club>().OrderBy(c => c.club_id).ToListAsync()) ;
        }

        public async Task<List<JobModel>> GetJobs()
        {
            return  _mapper.Map<List<JobModel>>(await _dbCon.Set<Job>().OrderBy(j => j.job_id).ToListAsync());
        }

        public async Task<List<SubjectModel>> GetSubjects()
        {
            return _mapper.Map<List<SubjectModel>>(await _dbCon.Set<Subject>().OrderBy(s => s.subject_id).ToListAsync()) ;

        }

        public async Task<List<InterestModel>> GetInterests()
        {
            return _mapper.Map<List<InterestModel>>(await _dbCon.Set<Interest>().OrderBy(i => i.interest_id).ToListAsync());
        }
    }
}