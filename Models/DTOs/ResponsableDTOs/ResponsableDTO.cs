using ApiRest.Utils.Enum;

namespace ApiRest.Models.DTOs.ResponsableDTOs
{
    public class ResponsableDTO
    {
        public int IdResponsable { get; set; }

        public int IdEmpleado { get; set; }
        public int IdEmpresa { get; set; }

        public CargoResponsable Cargo { get; set; }

        public string EmailContacto { get; set; } = default!;
        public string TelefonoContacto { get; set; } = default!;
        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    
    } 
}


