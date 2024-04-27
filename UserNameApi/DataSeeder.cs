using UserNameApi.Models.DbModels;

namespace UserNameApi;

public class DataSeeder
{
    private readonly WorkoutDbContext _dbContext;

    public DataSeeder(WorkoutDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (!_dbContext.Workouts.Any())
        {
            var workouts = new List<Workout>
            {
                new Workout
                {
                    StartDate = 1713630226,
                    EndDate = 1713630416,
                    WorkoutSessions = new List<WorkoutSession>
                    {
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Тяга верхнего блока"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Тяга нижнего блока"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Приседания со штангой"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 25,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 25,
                                    Reps = 12
                                }
                            }
                        }
                    }
                },
                new Workout
                {
                    StartDate = 1713630456,
                    EndDate = 1713630868,
                    WorkoutSessions = new List<WorkoutSession>
                    {
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Разгибание рук в блоке (канатная рукоять)"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Подъём штанги на бицепс"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                }
                            }
                        }
                    }
                }
            };

            _dbContext.Workouts.AddRange(workouts);
            _dbContext.SaveChanges();

            var workouts2 = new List<Workout>
            {
                new Workout
                {
                    StartDate = 1713630950,
                    EndDate = 1713631255,
                    WorkoutSessions = new List<WorkoutSession>
                    {
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Жим штанги лёжа"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Разгибание рук в блоке (канатная рукоять)"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Жим штанги лёжа узким хватом"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Жим гантелей лёжа"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 12,
                                    Reps = 10
                                },
                                new WorkoutSet
                                {
                                    Weight = 12,
                                    Reps = 10
                                },
                                new WorkoutSet
                                {
                                    Weight = 12,
                                    Reps = 10
                                }
                            }
                        }
                    }
                },
                new Workout
                {
                    StartDate = 1713710553,
                    EndDate = 1713713732,
                    WorkoutSessions = new List<WorkoutSession>
                    {
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Тяга верхнего блока"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 35,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Тяга нижнего блока"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 35,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = new WorkoutExcercise
                            {
                                Name = "Подтягивания на тренажёре"
                            },
                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 28,
                                    Reps = 8
                                },
                                new WorkoutSet
                                {
                                    Weight = 28,
                                    Reps = 8
                                },
                                new WorkoutSet
                                {
                                    Weight = 28,
                                    Reps = 8
                                },
                                new WorkoutSet
                                {
                                    Weight = 28,
                                    Reps = 8
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Приседания со штангой"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 25,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 25,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 25,
                                    Reps = 12
                                }
                            }
                        }
                    }
                },
                new Workout
                {
                    StartDate = 1713974079,
                    EndDate = 1713976649,
                    WorkoutSessions = new List<WorkoutSession>
                    {
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Подъём штанги на бицепс"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 15,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Разгибание рук в блоке (канатная рукоять)"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 10,
                                    Reps = 12
                                }
                            }
                        },
                        new WorkoutSession
                        {
                            WorkoutExcercise = _dbContext.WorkoutExcercises
                                .SingleOrDefault(x => x.Name == "Тяга верхнего блока"),

                            WorkoutSets = new List<WorkoutSet>
                            {
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 30,
                                    Reps = 12
                                },
                                new WorkoutSet
                                {
                                    Weight = 35,
                                    Reps = 12
                                }
                            }
                        }
                    }
                }
            };

            _dbContext.Workouts.AddRange(workouts2);
            _dbContext.SaveChanges();
        }
    }
}