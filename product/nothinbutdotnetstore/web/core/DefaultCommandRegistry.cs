using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public DefaultCommandRegistry():this(build_fake_set_of_commands())
        {
        }

        static IEnumerable<RequestCommand> build_fake_set_of_commands()
        {
            var results= new List<RequestCommand>();
            results.Add(new DefaultRequestCommand(x => x.GetType()==typeof(StubRequestFactory.StubRequest), new ViewMainDepartments()));
            results.Add(new DefaultRequestCommand(x => x.GetType()==typeof(ViewSubDepartmentRequest), new ViewSubDepartmentsInDepartment()));
            return results;
        }

        public RequestCommand get_command_that_can_handle(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request))
                   ?? new MissingRequestCommand();
        }
    }
}