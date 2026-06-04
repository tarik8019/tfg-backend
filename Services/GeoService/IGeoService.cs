namespace ApiRest.Services.GeoService
{
    public interface IGeoService
    {
        double CalcularDistancia(double lat1, double lon1, double lat2, double lon2);
    }
}
