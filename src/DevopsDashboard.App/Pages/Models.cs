namespace DevopsDashboard.App.Pages;

public class ServerMetric
{
    public string ServerName { get; set; } = string.Empty;
    public int CpuUsage { get; set; }
    public int RamUsage { get; set; }
    public string Status { get; set; } = "Healthy";
    public bool IsCritical => CpuUsage > 85 || RamUsage > 90;

    public void UpdateMetrics(int cpu, int ram)
    {
        if (cpu < 0 || cpu > 100 || ram < 0 || ram > 100)
            throw new ArgumentOutOfRangeException("Metrics must be between 0 and 100");

        CpuUsage = cpu;
        RamUsage = ram;
        
        if (CpuUsage > 90 || RamUsage > 95) Status = "Critical";
        else if (CpuUsage > 75 || RamUsage > 80) Status = "Warning";
        else Status = "Healthy";
    }
}

public class DeploymentConfig
{
    // OPTION 1: THEME TOGGLE
    // Change false to true to activate Dark Cyberpunk mode instantly!
    public static bool EnableCyberpunkTheme = false; 

    // OPTION 2: SIMULATE INFRASTRUCTURE FAILURE (Chaos Engineering)
    // Change false to true to simulate a node outage. 
    // This will instantly trigger an alert badge on the UI and can be used to test if students notice system alerts!
    public static bool SimulateNodeOutage = false;

    // OPTION 3: CUSTOM CLUSTER NAME (String Manipulation)
    // Students can personalize their deployment by putting their own name or team name here!
    public static string CustomClusterName = "Production-Cluster-Alpha";

    // OPTION 4: REFRESH INTERVAL (Performance Tuning)
    // Simulates changing application performance parameters. Lower values mean faster data fetching.
    public static int MetricRefreshRateSeconds = 5;


    public static string GetThemeClass() => EnableCyberpunkTheme 
        ? "from-purple-900 via-pink-900 to-red-900 text-cyan-300 border-cyan-400 border-2 shadow-[0_0_15px_rgba(34,211,238,0.5)]" 
        : "from-slate-800 to-slate-900 text-slate-100 border-slate-700";
}
