using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Util
{
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static IServiceProvider Instance
        {
            get
            {
                if (_serviceProvider == null)
                    throw new InvalidOperationException("Service provider not set. Call Initialize before accessing Instance.");

                return _serviceProvider;
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
