using ApiRest.Models.DTOs.FichajeDTOs;
using ApiRest.Models.Entity;
using ApiRest.Repository.IRepository;
using ApiRest.Services.GeoService;
using ApiRest.Services.IServices;
using AutoMapper;



namespace ApiRest.Services
    {
        public class FichajeService : IFichajeService
        {
            private readonly IFichajeRepository _fichajeRepository;
            private readonly IGeoService _geoService;
            private readonly IMapper _mapper;
            private readonly ILogger<FichajeService> _logger;

        public FichajeService(
                IFichajeRepository fichajeRepository,
                IGeoService geoService,
                IMapper mapper,
                ILogger<FichajeService> logger)
            {
                _fichajeRepository = fichajeRepository;
                _geoService = geoService;
                _mapper = mapper;
                _logger = logger;
        }

            public async Task<(bool Success, string? Error, FichajeEntity? Fichaje)>
                CrearFichajeAsync(CreateFichajeDTO dto)
            {
                // Obtener turno activo
                var turno = await _fichajeRepository
                    .GetTurnoActivoEmpleadoAsync(dto.IdEmpleado);

                if (turno == null)
                {
                    return (false,
                        "El empleado no tiene un turno activo.",
                        null);
                }

                // Validar horario
                var horaActual = DateTime.Now.TimeOfDay;

                if (!EstaDentroDelHorario(
                        horaActual,
                        turno.HoraInicio,
                        turno.HoraFin))
                {
                    return (false,
                        "El fichaje está fuera del horario del turno.",
                        null);
                }

                // Obtener sede
                var sede = turno.Sede;

                if (sede == null)
                {
                    return (false,
                        "El turno no tiene sede asignada.",
                        null);
                }

                // Validar geolocalización
                var distancia = _geoService.CalcularDistancia(
                    (double)dto.Latitud!,
                    (double)dto.Longitud!,
                    (double)sede.Latitud,
                    (double)sede.Longitud
                );

            _logger.LogInformation($"DTO Lat: {dto.Latitud}, DTO Lon: {dto.Longitud}");
            _logger.LogInformation($"Sede: {sede.Nombre}, Lat: {sede.Latitud}, Lon: {sede.Longitud}, Radio: {sede.RadioGeofencing}");
            _logger.LogInformation($"Distancia calculada: {distancia}");

            if (distancia > sede.RadioGeofencing)
                {
                    return (false,
                        "No se encuentra dentro del radio permitido.",
                        null);
                }

                // Crear fichaje
                var fichaje = _mapper.Map<FichajeEntity>(dto);

                fichaje.Timestamp = DateTime.Now;

                await _fichajeRepository.CreateAsync(fichaje);

                return (true, null, fichaje);
            }

            private bool EstaDentroDelHorario(
                TimeSpan actual,
                TimeSpan inicio,
                TimeSpan fin)
            {
                // Turno normal
                if (inicio < fin)
                {
                    return actual >= inicio &&
                           actual <= fin;
                }

                // Turno nocturno
                return actual >= inicio ||
                       actual <= fin;
            }
        }
    }

