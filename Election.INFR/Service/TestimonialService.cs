using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Election.INFR.Service
{
    public class TestimonialService : ISharedService<Etestimonial>,ITestimonialService
    {
        private readonly ISharedRepository<Etestimonial> _sharedRepository;
        private readonly ITestimonialRepository _testimonialRepository;


        public TestimonialService(ISharedRepository<Etestimonial> sharedRepository, ITestimonialRepository testimonialRepository)
        {
            _sharedRepository = sharedRepository;
            _testimonialRepository = testimonialRepository;
        }

        public Etestimonial Create(Etestimonial etestimonial)
        {
            return _sharedRepository.Create(etestimonial);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Etestimonial> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Etestimonial GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<HomeTestimonial> homeTestimonials()
        {
            return _testimonialRepository.homeTestimonials();
        }

        public Etestimonial Update(Etestimonial etestimonial)
        {
            return _sharedRepository.Update(etestimonial);
        }
    }
}
