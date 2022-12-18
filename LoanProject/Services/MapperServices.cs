using AutoMapper;
using LoanProject.Domain;
using LoanProject.Models;

namespace LoanProject.Services
{

    public interface IMapperServices
    {
         List<UserModel> AdaptUser(List<User> user);
        LoanModel AdaptLoan(Loan loan);
        List<LoanModel> AdaptLoanList(List<Loan> loan);
       PutLoanModel AdaptPutLoan(Loan loan);
    }
    public class MapperServices : IMapperServices
    {
        public  List<UserModel> AdaptUser(List<User> user)
        {

            var config = new MapperConfiguration(cfg =>

                    cfg.CreateMap<User, UserModel>()

                );



            List<UserModel> userModelList = new();

            var mapper = new Mapper(config);

            UserModel? usermodel;

            foreach (var i in user)
            {
                usermodel = mapper.Map<UserModel>(i);
                userModelList.Add(usermodel);

            }


            return userModelList;
        }


        public  List<LoanModel> AdaptLoanList(List<Loan> loan)
        {

            var config = new MapperConfiguration(cfg =>

                    cfg.CreateMap<Loan, LoanModel>()

                );



            List<LoanModel> loanModelList = new();

            var mapper = new Mapper(config);

            LoanModel? loanmodel;

            foreach (var i in loan)
            {
                loanmodel = mapper.Map<LoanModel>(i);
                loanModelList.Add(loanmodel);

            }


            return loanModelList;
        }


        public PutLoanModel AdaptPutLoan(Loan loan)
        {

            var config = new MapperConfiguration(cfg =>

                    cfg.CreateMap<Loan, PutLoanModel>()

                );


            var mapper = new Mapper(config);

            PutLoanModel? loanmodel;
            loanmodel = mapper.Map<PutLoanModel>(loan);
            return loanmodel;
        }




        public LoanModel AdaptLoan(Loan loan)
        {

            var config = new MapperConfiguration(cfg =>

                    cfg.CreateMap<Loan, LoanModel>()

                );



           

            var mapper = new Mapper(config);

            LoanModel? loanmodel;

          
                loanmodel = mapper.Map<LoanModel>(loan);
               

            


            return loanmodel;
        }
    }
}
