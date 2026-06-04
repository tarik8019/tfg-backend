namespace ApiRest.Utils.Enum
{
    public enum EstadoSolicitudAusencia
    {
        Pendiente,   // La solicitud fue creada y está esperando revisión
        Aprobada,    // La solicitud fue aprobada por el responsable
        Rechazada,   // La solicitud fue rechazada
        Cancelada,   // La solicitud fue cancelada por el empleado
        Archivada    // La solicitud ya fue procesada y archivada
    }

}
