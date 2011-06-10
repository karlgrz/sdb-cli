using System;
using System.Collections.Generic;
using Mono.Debugger.Cli.Debugging;
using Mono.Debugger.Cli.Logging;

namespace Mono.Debugger.Cli.Commands
{
    public sealed class ContinueCommand : ICommand
    {
        public string Name
        {
            get { return "Continue"; }
        }

        public string Description
        {
            get { return "Continues the debuggee process."; }
        }

        public IEnumerable<string> Arguments
        {
            get { return Argument.None(); }
        }

        public void Execute(CommandArguments args)
        {
            var session = SoftDebugger.Session;

            if (session == null)
            {
                Logger.WriteErrorLine("No process active.");
                return;
            }

            if (session.IsRunning)
            {
                Logger.WriteErrorLine("Process is already running.");
                return;
            }

            session.Continue();
        }
    }
}