using System;

namespace PlanetMissionConsole;

internal class Mars : PlanetMission
{
    public Mars()
    {
        kmToPlanet = 92_000_000;
        fuelPerKm = 1.73f;
        kmPerHour = 37_000;
    }
}
