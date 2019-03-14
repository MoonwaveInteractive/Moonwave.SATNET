// (c) 2019 Moonwave Interactive. All rights reserved under MIT License.

namespace Moonwave.SATNET
{
    /// <summary>
    /// Specifies constants that define assesment states.
    /// </summary>
    public enum AssesmentState
    {
        /// <summary>
        /// The assesment data is valid for the current computer configuration.
        /// </summary>
        Valid,

        /// <summary>
        /// The assesmentdata is not valid.
        /// </summary>
        Invalid,

        /// <summary>
        /// The assesment data does not match the current computer configuration.
        /// </summary>
        Incoherent,

        /// <summary>
        /// The assesment data is not available because a formal WinSAT assesment
        /// has not been run on this computer.
        /// </summary>
        Unavailable,

        /// <summary>
        /// The state of the assesment is unknown.
        /// </summary>
        Unknown
    }
}