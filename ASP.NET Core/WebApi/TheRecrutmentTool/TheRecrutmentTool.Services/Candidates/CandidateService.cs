using TheRecrutmentTool.Services.Skills.Models;

namespace TheRecrutmentTool.Services.Candidates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Skills;
    using TheRecrutmentTool.ViewModels.Candidates;
    using Data.Models;
    using Models;

    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _data;

        public CandidateService(ApplicationDbContext data)
            => _data = data;

        public void Create(CreateCandidateFormModel model)
        {
            var recruiter = _data
                .Recruiters
                .OrderBy(x => Guid.NewGuid().ToString())
                .FirstOrDefault();

            var candidate = new Candidate
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Biography = model.Biography,
                Birthdate = model.Birthdate,
                Email = model.Email,
                RecruiterId = recruiter.Id,
            };

            foreach (var candidateSkillInputModel in model.Skills)
            {
                var skill = _data.Skills.FirstOrDefault(x => x.Name == candidateSkillInputModel.Name);

                _data.CandidateSkills.Add(new CandidateSkill
                {
                    Candidate = candidate,
                    Skill = skill != null
                        ? skill
                        : new Skill
                        {
                            Name = candidateSkillInputModel.Name,
                        },
                });
            }

            _data.Candidates.Add(candidate);
            _data.SaveChanges();
        }

        public IEnumerable<CandidateServiceModel> GetAll()
            => _data
                .Candidates
                .Where(x => !x.IsDeleted)
                .Select(x => new CandidateServiceModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Biography = x.Biography,
                    Birthdate = x.Birthdate,
                    Skills = x.CandidateSkills
                        .Where(cs => cs.CandidateId == x.Id)
                        .Select(cs => new SkillServiceModel
                        {
                            Name = cs.Skill.Name,
                        }),
                    Recruiter = new CandidateRecruiterServiceModel
                    {
                        LastName = x.Recruiter.LastName,
                        Email = x.Recruiter.Email,
                        Country = x.Recruiter.Country,
                    }
                })
                .ToList();

        public CandidateServiceModel GetById(int id)
            => _data
                .Candidates
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new CandidateServiceModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Biography = x.Biography,
                    Birthdate = x.Birthdate,
                    Skills = x.CandidateSkills
                        .Where(cs => cs.CandidateId == x.Id)
                        .Select(cs => new SkillServiceModel
                        {
                            Name = cs.Skill.Name,
                        })
                        .ToList(),
                    Recruiter = new CandidateRecruiterServiceModel
                    {
                        LastName = x.Recruiter.LastName,
                        Email = x.Recruiter.Email,
                        Country = x.Recruiter.Country,
                    }
                })
                .FirstOrDefault();

        public bool EditById(int id, CreateCandidateFormModel model)
        {
            var candidate = _data.Candidates.FirstOrDefault(x => x.Id == id);

            if (candidate == null)
            {
                return false;
            }

            candidate.FirstName = model.FirstName;
            candidate.LastName = model.LastName;
            candidate.Email = model.Email;
            candidate.Biography = model.Biography;
            candidate.Birthdate = model.Birthdate;

            _data.SaveChanges();

            return true;
        }

        public bool DeleteById(int id)
        {
            var candidate = _data.Candidates.FirstOrDefault(x => x.Id == id);

            if (candidate == null)
            {
                return false;
            }

            candidate.IsDeleted = true;
            _data.SaveChanges();

            return true;
        }
    }
}
