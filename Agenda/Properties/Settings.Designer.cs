﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agenda.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Access")]
        public string DBType {
            get {
                return ((string)(this["DBType"]));
            }
            set {
                this["DBType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AgendaData")]
        public string MapperFactoryDllName {
            get {
                return ((string)(this["MapperFactoryDllName"]));
            }
            set {
                this["MapperFactoryDllName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AgendaData.mermec.MapperFactory")]
        public string MapperFactoryClassName {
            get {
                return ((string)(this["MapperFactoryClassName"]));
            }
            set {
                this["MapperFactoryClassName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source =.\\NOESIS; Initial Catalog = Mermec; User ID =RegUsr; Password =RegUs" +
            "r")]
        public string SqlConnectionString {
            get {
                return ((string)(this["SqlConnectionString"]));
            }
            set {
                this["SqlConnectionString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\\\users\\\\fgran\\\\TestMermec.mdb")]
        public string AccessConnectionString {
            get {
                return ((string)(this["AccessConnectionString"]));
            }
            set {
                this["AccessConnectionString"] = value;
            }
        }
    }
}
