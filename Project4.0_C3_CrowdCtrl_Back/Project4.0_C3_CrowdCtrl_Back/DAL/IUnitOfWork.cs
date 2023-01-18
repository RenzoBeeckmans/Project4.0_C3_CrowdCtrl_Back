using Project4._0_C3_CrowdCtrl_Back.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;

namespace Project4._0_C3_CrowdCtrl_Back.DAL
{
    public interface IUnitOfWork
    {

        IGenericRepository<Event> EventRepository { get; }
        IGenericRepository<EventType> EventTypeRepository { get; }
        IGenericRepository<EventUser> EventUserRepository { get; }
        IGenericRepository<Feedback> FeedbackRepository { get; }
        IGenericRepository<Models.Group> GroupRepository { get; }
        IGenericRepository<GroupGuard> GroupGuardRepository { get; }
        IGenericRepository<Guard> GuardRepository { get; }
        IGenericRepository<Incident> IncidentRepository { get; }
        IGenericRepository<RecordingDevice> RecordingDeviceRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Zone> ZoneRepository { get; }

        Task SaveChangesAsync();
    }
}
