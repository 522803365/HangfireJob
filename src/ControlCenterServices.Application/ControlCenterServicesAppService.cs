using ControlCenterServices.Domain.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace ControlCenterServices.Application
{
    /* Inherit your application services from this class.
     */
    public abstract class ControlCenterServicesAppService : ApplicationService
    {
        protected ControlCenterServicesAppService()
        {
            LocalizationResource = typeof(ControlCenterServicesResource);
        }
    }
}
