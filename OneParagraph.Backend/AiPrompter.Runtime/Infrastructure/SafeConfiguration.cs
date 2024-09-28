using Microsoft.Extensions.Configuration;
using System;

namespace AiPrompter.Runtime.Infrastructure;

public class SafeConfiguration
{
    private IConfiguration Configuration { get; }

    public SafeConfiguration(IConfiguration configuration) =>
        Configuration = configuration;

    public string this[string key]
    {
        get
        {
            var value = Configuration[key];
            return string.IsNullOrWhiteSpace(value) ? throw new InvalidOperationException($"{key} configuration is missing") : value;
        }
    }
}
