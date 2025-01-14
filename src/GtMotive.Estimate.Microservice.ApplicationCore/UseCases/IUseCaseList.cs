using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Use Case interface.
    /// </summary>
    /// <typeparam name="TUseCaseInput">Input Message.</typeparam>
    /// <typeparam name="TUseCaseOutput">Output Message.</typeparam>
    public interface IUseCaseList<in TUseCaseInput, TUseCaseOutput>
        where TUseCaseInput : IUseCaseInput
        where TUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Execute the use case.
        /// </summary>
        /// <param name="input">The input of the use case.</param>
        /// <returns>The output of the use case.</returns>
        Task<IEnumerable<TUseCaseOutput>> Execute(TUseCaseInput input);
    }
}
