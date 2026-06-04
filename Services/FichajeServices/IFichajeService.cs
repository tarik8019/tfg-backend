using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.Entity;




namespace ApiRest.Services.IServices
    {
        public interface IFichajeService
        {
            Task<(bool Success, string? Error, FichajeEntity? Fichaje)>
                CrearFichajeAsync(CreateFichajeDTO dto);
        }
    }


