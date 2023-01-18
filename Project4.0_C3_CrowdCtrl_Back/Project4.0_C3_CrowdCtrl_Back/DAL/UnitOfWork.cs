using Project4._0_C3_CrowdCtrl_Back.Models;
using Project4._0_C3_CrowdCtrl_Back.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project4._0_C3_CrowdCtrl_Back.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private IGenericRepository<Event> eventRepository;
        public IGenericRepository<Event> EventRepository
        {
            get
            {
                if (eventRepository == null)
                {
                    eventRepository = new EventRepository(_context);
                }

                return eventRepository;
            }
        }

        private IGenericRepository<EventType> eventTypeRepository;
        public IGenericRepository<EventType> EventTypeRepository
        {
            get
            {
                if (eventTypeRepository == null)
                {
                    eventTypeRepository = new EventTypeRepository(_context);
                }

                return eventTypeRepository;
            }
        }

        private IGenericRepository<EventUser> eventUserRepository;
        public IGenericRepository<EventUser> EventUserRepository
        {
            get
            {
                if (eventUserRepository == null)
                {
                    eventUserRepository = new EventUserRepository(_context);
                }

                return eventUserRepository;
            }
        }

        private IGenericRepository<Feedback> feedbackRepository;
        public IGenericRepository<Feedback> FeedbackRepository
        {
            get
            {
                if (feedbackRepository == null)
                {
                    feedbackRepository = new FeedbackRepository(_context);
                }

                return feedbackRepository;
            }
        }

        private IGenericRepository<Group> groupRepository;
        public IGenericRepository<Group> GroupRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(_context);
                }

                return groupRepository;
            }
        }

        private IGenericRepository<GroupGuard> groupGuardRepository;
        public IGenericRepository<GroupGuard> GroupGuardRepository
        {
            get
            {
                if (groupGuardRepository == null)
                {
                    groupGuardRepository = new GroupGuardRepository(_context);
                }

                return groupGuardRepository;
            }
        }

        private IGenericRepository<Guard> guardRepository;
        public IGenericRepository<Guard> GuardRepository
        {
            get
            {
                if (guardRepository == null)
                {
                    guardRepository = new GuardRepository(_context);
                }

                return guardRepository;
            }
        }

        private IGenericRepository<Incident> incidentRepository;
        public IGenericRepository<Incident> IncidentRepository
        {
            get
            {
                if (incidentRepository == null)
                {
                    incidentRepository = new IncidentRepository(_context);
                }

                return incidentRepository;
            }
        }

        private IGenericRepository<RecordingDevice> recordingDeviceRepository;
        public IGenericRepository<RecordingDevice> RecordingDeviceRepository
        {
            get
            {
                if (recordingDeviceRepository == null)
                {
                    recordingDeviceRepository = new RecordingDeviceRepository(_context);
                }

                return recordingDeviceRepository;
            }
        }

        private IGenericRepository<User> userRepository;
        public IGenericRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }

                return userRepository;
            }
        }

        private IGenericRepository<Zone> zoneRepository;
        public IGenericRepository<Zone> ZoneRepository
        {
            get
            {
                if (zoneRepository == null)
                {
                    zoneRepository = new ZoneRepository(_context);
                }

                return zoneRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
