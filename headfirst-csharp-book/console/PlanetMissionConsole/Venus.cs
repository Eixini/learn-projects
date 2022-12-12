using System;

namespace PlanetMissionConsole;

internal class Venus : PlanetMission
{
    public Venus()
    {
        kmToPlanet = 41_000_000;
        fuelPerKm = 2.11f;
        kmPerHour = 29_500;
    }
}
