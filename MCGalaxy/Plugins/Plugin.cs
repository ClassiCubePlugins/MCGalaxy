/*
    Copyright 2010 MCSharp team (Modified for use with MCZall/MCLawl/MCGalaxy)
    
    Dual-licensed under the Educational Community License, Version 2.0 and
    the GNU General Public License, Version 3 (the "Licenses"); you may
    not use this file except in compliance with the Licenses. You may
    obtain a copy of the Licenses at
    
    http://www.opensource.org/licenses/ecl2.php
    http://www.gnu.org/licenses/gpl-3.0.html
    
    Unless required by applicable law or agreed to in writing,
    software distributed under the Licenses are distributed on an "AS IS"
    BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
    or implied. See the Licenses for the specific language governing
    permissions and limitations under the Licenses.
*/
using System;

namespace MCGalaxy {

    /// <summary> Importance of a plugin event handler (See IPluginEvent). </summary>
    /// <remarks> Higher priority handlers are called before lower priority handlers. </remarks>
    public enum Priority : byte {
        Low = 0,
        Normal = 1,
        High = 2,
        Critical = 3,
        System_Level = 4
    }
  
    /// <summary> This class provides for more advanced modification to MCGalaxy </summary>
    public abstract partial class Plugin {

        /// <summary> Hooks into events and initalises states/resources etc </summary>
        /// <param name="startup"> True if plugin is being auto loaded due to server starting up, false if manually. </param>
        public abstract void Load(bool startup);
        
        /// <summary> Unhooks from events and disposes of state/resources etc </summary>
        /// <param name="shutdown"> True if plugin is being auto unloaded due to server shutting down, false if manually. </param>
        public abstract void Unload(bool shutdown);
        
        /// <summary> Called when a player does /Help on the plugin. Typically tells the player what this plugin is about. </summary>
        /// <param name="p"> Player who is doing /Help. </param>
        public virtual void Help(Player p) {
            p.Message("No help is available for this plugin.");
        }
        
        /// <summary> Name of the plugin. </summary>
        public abstract string name { get; }
        /// <summary> Your website. </summary>
        public virtual string website { get { return ""; } }
        /// <summary> Oldest version of MCGalaxy this plugin is compatible with. </summary>
        public abstract string MCGalaxy_Version { get; }
        /// <summary> Version of this plugin. </summary>
        public virtual int build { get { return 0; } }
        /// <summary> Message to display once this plugin is loaded. </summary>
        public virtual string welcome { get { return ""; } }
        /// <summary> The creator/author of this plugin. (Your name) </summary>
        public virtual string creator { get { return ""; } }
        /// <summary> Whether or not to auto load this plugin on server startup. </summary>
        public virtual bool LoadAtStartup { get { return true; } }
    }

    // This class is just kept around for backwards compatibility    
    //   Plugin used to be completely abstract, with Plugin_Simple having virtual methods
    //   However this is now obsolete as the virtual methods were moved into Plugin
    [Obsolete("Derive from Plugin instead", true)]
    public abstract class Plugin_Simple : Plugin { }
}

