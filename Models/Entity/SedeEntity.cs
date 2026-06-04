using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiRest.Models.Entity
{
    public class SedeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSede { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        public decimal Latitud { get; set; }

        [Required]
        public decimal Longitud { get; set; }

        // El empleado sólo puede fichar si está a menos de 100 metros de la sede.
        [Required]
        public int RadioGeofencing { get; set; }

        // Relación 1:N con TurnoEntity
        [JsonIgnore]
        public ICollection<TurnoEntity> Turnos { get; set; } = new List<TurnoEntity>();
    }
}
