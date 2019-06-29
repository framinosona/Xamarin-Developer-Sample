using System;

namespace DeveloperSample.Core.Converters
{
    /// <summary>
    ///     When annotated onto an <see cref="Xamarin.Forms.IValueConverter" /> implementation, enables third party tools to
    ///     analyse the type-flow of binding expressions.
    ///     <para />
    ///     Usage: [ValueConversion(typeof(InputType), typeof(OutputType))]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ValueConversionAttribute : Attribute
    {
        public Type Input { get; }
        public Type Output { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:HelloMFractor.Converters.ValueConversionAttribute" /> class.
        /// </summary>
        /// <param name="input">The input type of the value converter.</param>
        /// <param name="output">The output type of the value converter.</param>
        public ValueConversionAttribute(Type input, Type output)
        {
            Input = input;
            Output = output;
        }

        /// <summary>
        ///     The parameter type of the value converter.
        /// </summary>
        /// <value>The type of the parameter.</value>
        public Type ParameterType
        {
            get;
            set;
        }
    }
}