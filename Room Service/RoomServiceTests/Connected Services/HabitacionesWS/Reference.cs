﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoomServiceTests.HabitacionesWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Habitacion", Namespace="http://schemas.datacontract.org/2004/07/RoomService.Dominio")]
    [System.SerializableAttribute()]
    public partial class Habitacion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int camasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool disponibilidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int numeroField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int camas {
            get {
                return this.camasField;
            }
            set {
                if ((this.camasField.Equals(value) != true)) {
                    this.camasField = value;
                    this.RaisePropertyChanged("camas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.descripcionField, value) != true)) {
                    this.descripcionField = value;
                    this.RaisePropertyChanged("descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool disponibilidad {
            get {
                return this.disponibilidadField;
            }
            set {
                if ((this.disponibilidadField.Equals(value) != true)) {
                    this.disponibilidadField = value;
                    this.RaisePropertyChanged("disponibilidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int numero {
            get {
                return this.numeroField;
            }
            set {
                if ((this.numeroField.Equals(value) != true)) {
                    this.numeroField = value;
                    this.RaisePropertyChanged("numero");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/RoomService.Errores")]
    [System.SerializableAttribute()]
    public partial class RepetidoException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HabitacionesWS.IHabitacionesService")]
    public interface IHabitacionesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerHabitacionResponse")]
        RoomServiceTests.HabitacionesWS.Habitacion ObtenerHabitacion(int numero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerHabitacionResponse")]
        System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> ObtenerHabitacionAsync(int numero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/CrearHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/CrearHabitacionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(RoomServiceTests.HabitacionesWS.RepetidoException), Action="http://tempuri.org/IHabitacionesService/CrearHabitacionRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/RoomService.Errores")]
        RoomServiceTests.HabitacionesWS.Habitacion CrearHabitacion(RoomServiceTests.HabitacionesWS.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/CrearHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/CrearHabitacionResponse")]
        System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> CrearHabitacionAsync(RoomServiceTests.HabitacionesWS.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ModificarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ModificarHabitacionResponse")]
        RoomServiceTests.HabitacionesWS.Habitacion ModificarHabitacion(RoomServiceTests.HabitacionesWS.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ModificarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ModificarHabitacionResponse")]
        System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> ModificarHabitacionAsync(RoomServiceTests.HabitacionesWS.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/EliminarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/EliminarHabitacionResponse")]
        void EliminarHabitacion(int numero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/EliminarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/EliminarHabitacionResponse")]
        System.Threading.Tasks.Task EliminarHabitacionAsync(int numero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitaciones", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesResponse")]
        RoomServiceTests.HabitacionesWS.Habitacion[] ListarHabitaciones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitaciones", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesResponse")]
        System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion[]> ListarHabitacionesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHabitacionesServiceChannel : RoomServiceTests.HabitacionesWS.IHabitacionesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HabitacionesServiceClient : System.ServiceModel.ClientBase<RoomServiceTests.HabitacionesWS.IHabitacionesService>, RoomServiceTests.HabitacionesWS.IHabitacionesService {
        
        public HabitacionesServiceClient() {
        }
        
        public HabitacionesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HabitacionesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HabitacionesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HabitacionesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RoomServiceTests.HabitacionesWS.Habitacion ObtenerHabitacion(int numero) {
            return base.Channel.ObtenerHabitacion(numero);
        }
        
        public System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> ObtenerHabitacionAsync(int numero) {
            return base.Channel.ObtenerHabitacionAsync(numero);
        }
        
        public RoomServiceTests.HabitacionesWS.Habitacion CrearHabitacion(RoomServiceTests.HabitacionesWS.Habitacion habitacion) {
            return base.Channel.CrearHabitacion(habitacion);
        }
        
        public System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> CrearHabitacionAsync(RoomServiceTests.HabitacionesWS.Habitacion habitacion) {
            return base.Channel.CrearHabitacionAsync(habitacion);
        }
        
        public RoomServiceTests.HabitacionesWS.Habitacion ModificarHabitacion(RoomServiceTests.HabitacionesWS.Habitacion habitacion) {
            return base.Channel.ModificarHabitacion(habitacion);
        }
        
        public System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion> ModificarHabitacionAsync(RoomServiceTests.HabitacionesWS.Habitacion habitacion) {
            return base.Channel.ModificarHabitacionAsync(habitacion);
        }
        
        public void EliminarHabitacion(int numero) {
            base.Channel.EliminarHabitacion(numero);
        }
        
        public System.Threading.Tasks.Task EliminarHabitacionAsync(int numero) {
            return base.Channel.EliminarHabitacionAsync(numero);
        }
        
        public RoomServiceTests.HabitacionesWS.Habitacion[] ListarHabitaciones() {
            return base.Channel.ListarHabitaciones();
        }
        
        public System.Threading.Tasks.Task<RoomServiceTests.HabitacionesWS.Habitacion[]> ListarHabitacionesAsync() {
            return base.Channel.ListarHabitacionesAsync();
        }
    }
}
