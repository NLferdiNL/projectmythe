using System.Collections.Generic;

public static class PlanetManager
{
	static List<Planet> planets = new List<Planet> ();

	public static void Register (Planet item)
	{
		if (!planets.Contains (item)) {
			planets.Add (item);
		}
	}

	public static void UnRegister (Planet item)
	{
		if (planets.Contains (item)) {
			planets.Remove (item);
		}
	}

	public static Planet[] GetPlanets ()
	{
		return planets.ToArray ();
	}
}
