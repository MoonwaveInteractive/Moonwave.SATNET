// (c) 2019 Moonwave Interactive. All rights reserved under MIT License.

using System;
using WINSATLib;

namespace Moonwave.SATNET
{
    /// <summary>
    /// Class providing several properties for retrieving assesment information from WinSAT.
    /// </summary>
    public static class Assesment
    {
        private static CQueryWinSAT query = new CQueryWinSAT();

        private static readonly CInitiateWinSAT winSAT = new CInitiateWinSAT();

        /// <summary>
        /// Gets the state of the most recent WinSAT assesment.
        /// </summary>
        public static AssesmentState State
        {
            get
            {
                AssesmentState assesmentState = AssesmentState.Invalid;

                switch (query.Info.AssessmentState)
                {
                    case WINSAT_ASSESSMENT_STATE.WINSAT_ASSESSMENT_STATE_VALID:
                        assesmentState = AssesmentState.Valid;
                        break;

                    case WINSAT_ASSESSMENT_STATE.WINSAT_ASSESSMENT_STATE_INCOHERENT_WITH_HARDWARE:
                        assesmentState = AssesmentState.Incoherent;
                        break;

                    case WINSAT_ASSESSMENT_STATE.WINSAT_ASSESSMENT_STATE_NOT_AVAILABLE:
                        assesmentState = AssesmentState.Unavailable;
                        break;

                    case WINSAT_ASSESSMENT_STATE.WINSAT_ASSESSMENT_STATE_UNKNOWN:
                        assesmentState = AssesmentState.Unknown;
                        break;

                    default:
                        assesmentState = AssesmentState.Invalid;
                        break;
                }

                return assesmentState;
            }
        }

        /// <summary>
        /// Gets the score for the processors on the computer.
        /// </summary>
        public static float CPUScore
        {
            get
            {
                return query.Info.GetAssessmentInfo(WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_CPU).Score;
            }
        }

        /// <summary>
        /// Gets the score for the memory throughput and capacity of the computer.
        /// </summary>
        public static float MemoryScore
        {
            get
            {
                return query.Info.GetAssessmentInfo(WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_MEMORY).Score;
            }
        }

        /// <summary>
        /// Gets the score for the sequential read throughput on the primary hard disk on the computer.
        /// </summary>
        public static float DiskScore
        {
            get
            {
                return query.Info.GetAssessmentInfo(WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_DISK).Score;
            }
        }

        /// <summary>
        /// Gets the score for the graphics capabilities of the computer.
        /// </summary>
        public static float GraphicsScore
        {
            get
            {
                return query.Info.GetAssessmentInfo(WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_GRAPHICS).Score;
            }
        }

        /// <summary>
        /// Gets the D3D score for the gaming graphics capabilities of the computer.
        /// </summary>
        [Obsolete("After Windows 8.1, WinSAT no longer assesses the three dimensional graphics (gaming) capabilities " +
                  "of the computer and the graphics driver's ability to render objects and execute shaders using " +
                  "this assessment. For compatability, WinSAT reports sentinel values for the metrics and scores, " +
                  "however these are not calculated in real time.")]
        public static float D3DScore
        {
            get
            {
                return query.Info.GetAssessmentInfo(WINSAT_ASSESSMENT_TYPE.WINSAT_ASSESSMENT_D3D).Score;
            }
        }

        /// <summary>
        /// Gets the base score of the computer.
        /// </summary>
        public static float BaseScore
        {
            get
            {
                return query.Info.SystemRating;
            }
        }

        /// <summary>
        /// Gets the date and time of the most recent assesment.
        /// </summary>
        public static DateTime DateTime
        {
            get
            {
                return query.Info.AssessmentDateTime;
            }
        }
    }
}