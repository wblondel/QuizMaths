using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace QuizMaths.Tests.Fixtures
{
    public class FrenchCultureFixture : IDisposable
    {
        private readonly CultureInfo _originalCulture;
        private readonly CultureInfo _originalUiCulture;
        private readonly CultureInfo? _originalDefaultCulture;
        private readonly CultureInfo? _originalDefaultUiCulture;

        public FrenchCultureFixture()
        {
            // Store all original cultures
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            _originalUiCulture = Thread.CurrentThread.CurrentUICulture;
            _originalDefaultCulture = CultureInfo.DefaultThreadCurrentCulture;
            _originalDefaultUiCulture = CultureInfo.DefaultThreadCurrentUICulture;

            // Create French culture
            var frenchCulture = new CultureInfo("fr-FR");

            // Set thread cultures
            Thread.CurrentThread.CurrentCulture = frenchCulture;
            Thread.CurrentThread.CurrentUICulture = frenchCulture;

            // Set default cultures for any new threads
            CultureInfo.DefaultThreadCurrentCulture = frenchCulture;
            CultureInfo.DefaultThreadCurrentUICulture = frenchCulture;

            // For .NET Core/.NET 5+ compatibility
            CultureInfo.CurrentCulture = frenchCulture;
            CultureInfo.CurrentUICulture = frenchCulture;

            Console.WriteLine("French culture set successfully in test fixture");
        }

        public void Dispose()
        {
            // Restore all original cultures
            Thread.CurrentThread.CurrentCulture = _originalCulture;
            Thread.CurrentThread.CurrentUICulture = _originalUiCulture;
            CultureInfo.DefaultThreadCurrentCulture = _originalDefaultCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _originalDefaultUiCulture;

            // For .NET Core/.NET 5+ compatibility
            CultureInfo.CurrentCulture = _originalCulture;
            CultureInfo.CurrentUICulture = _originalUiCulture;

            Console.WriteLine("Original culture restored in test fixture");
        }
    }

    [CollectionDefinition("French Culture Collection")]
    public class FrenchCultureCollection : ICollectionFixture<FrenchCultureFixture>
    {
        // This class has no code, and is never created.
        // Its purpose is just to be the place to apply [CollectionDefinition]
    }
}