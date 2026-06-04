namespace ApiRest.Utils.Enum
{
    public enum TipoReporte
    {
        Asistencia,        // Reporte de fichajes, entradas y salidas
        HorasTrabajadas,   // Total de horas trabajadas por empleado
        Ausencias,         // Días de ausencia y tipo de ausencia
        Vacaciones,        // Estado y saldo de vacaciones
        Incidencias,       // Retrasos, faltas, errores de fichaje
        Turnos,            // Asignación de turnos por empleado
        Nomina,            // Información de salarios y pagos
        Evaluaciones,      // Evaluaciones de desempeño
        Alertas            // Reportes generados por reglas de turno o alertas
    }

}
