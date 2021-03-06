﻿using System;
using System.ComponentModel;

namespace XCommand
{
    /// <summary>
    /// Interface defining an undo / redo command for a user interaction.
    /// </summary>
    public interface IUserCommand : INotifyPropertyChanged, ITooltipable
    {
        #region Properties

        /// <summary>
        /// Gets the command short description.
        /// </summary>
        string ShortDescription
        {
            get;
        }

        /// <summary>
        /// Gets the real time the command has been executed.
        /// </summary>
        TimeSpan RealTime
        {
            get;
        }

        /// <summary>
        /// Gets the simulation time the command has been executed.
        /// </summary>
        TimeSpan SimulationTime
        {
            get;
        }

        /// <summary>
        /// Gets the command execution timeout.
        /// </summary>
        TimeSpan? Timeout
        {
            get;
        }

        /// <summary>
        /// Gets the command specific state.
        /// </summary>
        UserCommandState State
        {
            get;
        }
        
        #endregion // Properties.

        #region Events

        /// <summary>
        /// Event raised to notify a command execution progression.
        /// </summary>
        event CommandExecutionEventHandler<IUserCommand> Doing;

        /// <summary>
        /// Event raised to notify a command execution successfully finished.
        /// </summary>
        event CommandExecutionEventHandler<IUserCommand> Done;

        /// <summary>
        /// Event raised to notify a command execution or revertion failed.
        /// </summary>
        event CommandExecutionEventHandler<IUserCommand> Failed;

        /// <summary>
        /// Event raised to notify a command revertion progression.
        /// </summary>
        event CommandExecutionEventHandler<IUserCommand> Undoing;

        /// <summary>
        /// Event raised to notify a command revertion successfully finished.
        /// </summary>
        event CommandExecutionEventHandler<IUserCommand> Undone;

        #endregion // Events.

        #region Methods

        /// <summary>
        /// Do the command.
        /// </summary>
        void Do();

        /// <summary>
        /// Do the commande and time stamp it.
        /// </summary>
        /// <param name="pRealTime">The relative real execution time.</param>
        /// <param name="pSimulationTime">The simulation time the command has been executed.</param>
        void TimeStampedDo(TimeSpan pRealTime, TimeSpan pSimulationTime);

        /// <summary>
        /// Undo the command.
        /// </summary>
        void Undo();

        /// <summary>
        /// Tries to merge the last executed command with this command.
        /// </summary>
        /// <param name="pLastExecutedCommand">The last executed command.</param>
        /// <returns>True if the command has been merge with this command.</returns>
        bool TryMerge(IUserCommand pLastExecutedCommand);

        #endregion // Methods.
    }
}
