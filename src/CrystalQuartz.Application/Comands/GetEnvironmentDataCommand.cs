
namespace CrystalQuartz.Application.Comands
{
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Application.Comands.Outputs;
    using CrystalQuartz.WebFramework.Commands;
    using Microsoft.Win32;
    using Quartz;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class GetEnvironmentDataCommand : AbstractCommand<NoInput, EnvironmentDataOutput>
    {
        private readonly string _customCssUrl;

        public GetEnvironmentDataCommand(string customCssUrl)
        {
            _customCssUrl = customCssUrl;
        }

        protected override Task InternalExecute(NoInput input, EnvironmentDataOutput output)
        {
            output.SelfVersion = GetAssemblyVersion(Assembly.GetCallingAssembly());
            output.QuartzVersion = GetAssemblyVersion(Assembly.GetAssembly(typeof(IScheduler)));
            output.DotNetVersion = GetDotNetVersion();
            output.CustomCssUrl = _customCssUrl;

            return Task.CompletedTask;
        }

        private string GetAssemblyVersion(Assembly assembly)
        {
            return string.Format("v{0}", assembly.GetName().Version);
        }

        private string GetDotNetVersion()
        {
            const string defaultDotNetVersion = "unknown";

            try
            {
                var installedVersions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                if (installedVersions != null)
                {
                    var versionNames = installedVersions.GetSubKeyNames();

                    return versionNames.Last();
                }

                return defaultDotNetVersion;
            }
            catch (Exception)
            {
                return defaultDotNetVersion;
            }
        }
    }
}