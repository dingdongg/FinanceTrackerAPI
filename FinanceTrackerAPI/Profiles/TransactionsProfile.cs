using AutoMapper;
using FinanceTrackerAPI.DTOs;

namespace FinanceTrackerAPI.Profiles
{
    public class TransactionsProfile : Profile
    {
        public TransactionsProfile()
        {
            CreateMap<Transaction, TransactionReadDTO>();
        }
    }
}
