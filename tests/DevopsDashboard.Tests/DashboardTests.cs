using Xunit;
using DevopsDashboard.App.Pages;

namespace DevopsDashboard.Tests;

public class DashboardTests
{
    [Fact]
    public void ServerMetric_Initialization_SetsDefaultsCorrectly()
    {
        var metric = new ServerMetric { ServerName = "test-node", CpuUsage = 50, RamUsage = 50 };
        Assert.Equal("test-node", metric.ServerName);
        Assert.Equal("Healthy", metric.Status);
        Assert.False(metric.IsCritical);
    }

    [Fact]
    public void UpdateMetrics_ValidInput_UpdatesValuesSuccessfully()
    {
        var metric = new ServerMetric();
        metric.UpdateMetrics(60, 70);
        Assert.Equal(60, metric.CpuUsage);
        Assert.Equal(70, metric.RamUsage);
    }

    [Fact]
    public void UpdateMetrics_HighCpu_TriggersWarningStatus()
    {
        var metric = new ServerMetric();
        metric.UpdateMetrics(78, 40);
        Assert.Equal("Warning", metric.Status);
    }

    [Fact]
    public void UpdateMetrics_HighRam_TriggersWarningStatus()
    {
        var metric = new ServerMetric();
        metric.UpdateMetrics(30, 82);
        Assert.Equal("Warning", metric.Status);
    }

    [Fact]
    public void UpdateMetrics_ExtremeCpu_TriggersCriticalStatus()
    {
        var metric = new ServerMetric();
        metric.UpdateMetrics(92, 40);
        Assert.Equal("Critical", metric.Status);
    }

    [Fact]
    public void UpdateMetrics_ExtremeRam_TriggersCriticalStatus()
    {
        var metric = new ServerMetric();
        metric.UpdateMetrics(40, 96);
        Assert.Equal("Critical", metric.Status);
    }

    [Fact]
    public void ServerMetric_IsCritical_ReturnsTrueWhenCpuExceedsThreshold()
    {
        var metric = new ServerMetric { CpuUsage = 86, RamUsage = 40 };
        Assert.True(metric.IsCritical);
    }

    [Fact]
    public void ServerMetric_IsCritical_ReturnsTrueWhenRamExceedsThreshold()
    {
        var metric = new ServerMetric { CpuUsage = 40, RamUsage = 92 };
        Assert.True(metric.IsCritical);
    }

    [Theory]
    [InlineData(-5, 50)]
    [InlineData(105, 50)]
    [InlineData(50, -20)]
    [InlineData(50, 150)]
    public void UpdateMetrics_InvalidValues_ThrowsOutOfRangeException(int cpu, int ram)
    {
        var metric = new ServerMetric();
        Assert.Throws<ArgumentOutOfRangeException>(() => metric.UpdateMetrics(cpu, ram));
    }

    [Fact]
    public void DeploymentConfig_DefaultTheme_ReturnsStandardClasses()
    {
        DeploymentConfig.EnableCyberpunkTheme = false;
        var theme = DeploymentConfig.GetThemeClass();
        Assert.Contains("from-slate-800", theme);
        Assert.DoesNotContains("from-purple-900", theme);
    }

    [Fact]
    public void DeploymentConfig_CyberpunkTheme_ReturnsCyberpunkClasses()
    {
        DeploymentConfig.EnableCyberpunkTheme = true;
        var theme = DeploymentConfig.GetThemeClass();
        Assert.Contains("from-purple-900", theme);
        Assert.Contains("shadow-", theme);
    }

    [Fact]
    public void DeploymentConfig_ThemeSwitch_AltersVisualOutput()
    {
        DeploymentConfig.EnableCyberpunkTheme = false;
        var standardTheme = DeploymentConfig.GetThemeClass();

        DeploymentConfig.EnableCyberpunkTheme = true;
        var cyberpunkTheme = DeploymentConfig.GetThemeClass();

        Assert.NotEqual(standardTheme, cyberpunkTheme);
    }
}
