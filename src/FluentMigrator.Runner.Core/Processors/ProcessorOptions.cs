using System;

using FluentMigrator.Runner.Initialization;

namespace FluentMigrator.Runner.Processors
{
    /// <summary>
    /// Options for an <see cref="IMigrationProcessor"/>
    /// </summary>
#pragma warning disable 612
    public sealed class ProcessorOptions : IMigrationProcessorOptions
#pragma warning restore 612
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessorOptions"/> class.
        /// </summary>
        public ProcessorOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessorOptions"/> class.
        /// </summary>
        /// <param name="runnerContext">The runner context to get the values from</param>
        [Obsolete]
        public ProcessorOptions(IRunnerContext runnerContext)
        {
            PreviewOnly = runnerContext.PreviewOnly;
            Timeout = runnerContext.Timeout == null
                ? null
                : (TimeSpan?) TimeSpan.FromSeconds(runnerContext.Timeout.Value);
            ProviderSwitches = runnerContext.ProviderSwitches;
            ConnectionString = runnerContext.Connection;
        }

        /// <summary>
        /// Gets or sets the connection string (will not be used when <see cref="PreviewOnly"/> is active)
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a preview-only mode is active
        /// </summary>
        public bool PreviewOnly { get; set; }

        /// <summary>
        /// Gets or sets the default command timeout
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the provider switches
        /// </summary>
        public string ProviderSwitches  { get; set; }

        /// <inheritdoc />
        int? IMigrationProcessorOptions.Timeout => Timeout == null ? null : (int?) Timeout.Value.TotalSeconds;
    }
}
