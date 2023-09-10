using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstrarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckRentalReturnTime(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.NewRentAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int Id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CustomerId == Id), Messages.ByBrandListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        private IResult CheckRentalReturnTime(Rental rental)
        {
            List<Rental> rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var rent in rentals)
            {
                if (rent.ReturnDate == null)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();

            
        }

    }
}
