using Final_project.DAL.Interfaces;
using Final_project.DAL.Repositories;
using Final_project.Domain.Entity;
using Final_project.Domain.Respons;
using Final_project.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project.Service.Implementations
{
    internal class SushiService : ISushiService
    {
        private readonly BaseRepository<Sushi> _sushiRepository;
        private readonly DbContext _context;

        public SushiService()
        {
        }

        public SushiService(BaseRepository<Sushi> sushiRepository)
        {
            _sushiRepository = sushiRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Sushi>>> GetSushiAsync()
        {
            var baseResponse = new BaseResponse<IEnumerable<Sushi>>();
            var sushies = await _sushiRepository.GetListAsync().ConfigureAwait(false);

            try
            {
                if (sushies == null)
                {
                    baseResponse.Discription = "Найдено 0 элементов";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                }

                baseResponse.Data = sushies;
                baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Sushi>>()
                {
                    Discription = $"[GetSushi] : {ex.Message}"
                };
            }

        }
    }
}
