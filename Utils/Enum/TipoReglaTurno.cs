namespace ApiRest.Utils.Enum
{
    public enum TipoReglaTurno
    {
        HorarioFijo,       // El empleado debe trabajar siempre el mismo horario
        HorarioFlexible,   // Puede empezar/terminar dentro de un rango
        MaxHorasDiarias,   // Limita las horas trabajadas por día
        MinHorasDiarias,   // Garantiza un mínimo de horas
        MaxHorasSemanal,   // Limita las horas trabajadas por semana
        DescansoObligatorio, // Requiere un tiempo mínimo de descanso entre turnos
        DiaLibreFijo,      // Día fijo libre por semana
        TurnoRotativo      // Cambia de turno de manera rotativa
    }

}
