using log4net;
using System.Collections.Generic;

namespace Kasi.Tools.Harvester.Domain.Tests.Utility.Extensions
{
    public static class ILogExtension
    {
        /// <summary>
        /// Logs a variable name and value to the debug output.
        /// </summary>
        /// <param name="log"></param>
        /// <param name="name">Name of the variable we are logging.</param>
        /// <param name="value">Value of the variable.</param>
        public static void Variable(this ILog log, string name, object value)
        {
            log.DebugFormat("{0} = {1}", name, value?.ToString());
        }

        private static Stack<string> Blocks => new Stack<string>();

        /// <summary>
        /// Logs the starts of a block of code.
        /// </summary>
        /// <param name="log">ILog instance</param>
        /// <param name="block">The block of code that we're starting.</param>
        public static void Start(this ILog log, string block)
        {
            // add the block to the end of our queue
            Blocks.Push(block);

            // get block hirarchy string
            var hirarchy = string.Join("::", Blocks);

            // log the start of the block
            log.DebugFormat("START::{0}", hirarchy);
        }

        /// <summary>
        /// Logs the starts of a block of code.
        /// </summary>
        /// <param name="log">ILog instance</param>
        /// <param name="block">The block of code that we're starting.</param>
        public static void End(this ILog log)
        {
            // get block hirarchy string
            var hirarchy = string.Join("::", Blocks);

            // log the start of the block
            log.DebugFormat("END::::{0}", hirarchy);

            // pop the last block from the end of our queue
            Blocks.Pop();
        }
    }
}
