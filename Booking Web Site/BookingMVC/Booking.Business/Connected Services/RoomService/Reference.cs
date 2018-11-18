﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Booking.Business.RoomService {
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
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CantidadCamasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoHabitacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoHotelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoimagenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DisponibleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HabitacionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumeroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PrecioField;
        
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
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CantidadCamas {
            get {
                return this.CantidadCamasField;
            }
            set {
                if ((this.CantidadCamasField.Equals(value) != true)) {
                    this.CantidadCamasField = value;
                    this.RaisePropertyChanged("CantidadCamas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoHabitacion {
            get {
                return this.CodigoHabitacionField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoHabitacionField, value) != true)) {
                    this.CodigoHabitacionField = value;
                    this.RaisePropertyChanged("CodigoHabitacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoHotel {
            get {
                return this.CodigoHotelField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoHotelField, value) != true)) {
                    this.CodigoHotelField = value;
                    this.RaisePropertyChanged("CodigoHotel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigoimagen {
            get {
                return this.CodigoimagenField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoimagenField, value) != true)) {
                    this.CodigoimagenField = value;
                    this.RaisePropertyChanged("Codigoimagen");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Disponible {
            get {
                return this.DisponibleField;
            }
            set {
                if ((this.DisponibleField.Equals(value) != true)) {
                    this.DisponibleField = value;
                    this.RaisePropertyChanged("Disponible");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int HabitacionId {
            get {
                return this.HabitacionIdField;
            }
            set {
                if ((this.HabitacionIdField.Equals(value) != true)) {
                    this.HabitacionIdField = value;
                    this.RaisePropertyChanged("HabitacionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Numero {
            get {
                return this.NumeroField;
            }
            set {
                if ((this.NumeroField.Equals(value) != true)) {
                    this.NumeroField = value;
                    this.RaisePropertyChanged("Numero");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Precio {
            get {
                return this.PrecioField;
            }
            set {
                if ((this.PrecioField.Equals(value) != true)) {
                    this.PrecioField = value;
                    this.RaisePropertyChanged("Precio");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoomService.IHabitacionesService")]
    public interface IHabitacionesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerHabitacionResponse")]
        Booking.Business.RoomService.Habitacion ObtenerHabitacion(int habitacionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerHabitacionResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ObtenerHabitacionAsync(int habitacionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerPorHotelYNumeroHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerPorHotelYNumeroHabitacionResponse")]
        Booking.Business.RoomService.Habitacion ObtenerPorHotelYNumeroHabitacion(string codigoHotel, int numeroHabitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ObtenerPorHotelYNumeroHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ObtenerPorHotelYNumeroHabitacionResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ObtenerPorHotelYNumeroHabitacionAsync(string codigoHotel, int numeroHabitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/CrearHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/CrearHabitacionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Booking.Business.RoomService.RepetidoException), Action="http://tempuri.org/IHabitacionesService/CrearHabitacionRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/RoomService.Errores")]
        Booking.Business.RoomService.Habitacion CrearHabitacion(Booking.Business.RoomService.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/CrearHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/CrearHabitacionResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> CrearHabitacionAsync(Booking.Business.RoomService.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ModificarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ModificarHabitacionResponse")]
        Booking.Business.RoomService.Habitacion ModificarHabitacion(Booking.Business.RoomService.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ModificarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/ModificarHabitacionResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ModificarHabitacionAsync(Booking.Business.RoomService.Habitacion habitacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/EliminarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/EliminarHabitacionResponse")]
        int EliminarHabitacion(int habitacionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/EliminarHabitacion", ReplyAction="http://tempuri.org/IHabitacionesService/EliminarHabitacionResponse")]
        System.Threading.Tasks.Task<int> EliminarHabitacionAsync(int habitacionId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitaciones", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesResponse")]
        Booking.Business.RoomService.Habitacion[] ListarHabitaciones();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitaciones", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion[]> ListarHabitacionesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitacionesPorHotel", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesPorHotelResponse")]
        Booking.Business.RoomService.Habitacion[] ListarHabitacionesPorHotel(string codigoHotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHabitacionesService/ListarHabitacionesPorHotel", ReplyAction="http://tempuri.org/IHabitacionesService/ListarHabitacionesPorHotelResponse")]
        System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion[]> ListarHabitacionesPorHotelAsync(string codigoHotel);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHabitacionesServiceChannel : Booking.Business.RoomService.IHabitacionesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HabitacionesServiceClient : System.ServiceModel.ClientBase<Booking.Business.RoomService.IHabitacionesService>, Booking.Business.RoomService.IHabitacionesService {
        
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
        
        public Booking.Business.RoomService.Habitacion ObtenerHabitacion(int habitacionId) {
            return base.Channel.ObtenerHabitacion(habitacionId);
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ObtenerHabitacionAsync(int habitacionId) {
            return base.Channel.ObtenerHabitacionAsync(habitacionId);
        }
        
        public Booking.Business.RoomService.Habitacion ObtenerPorHotelYNumeroHabitacion(string codigoHotel, int numeroHabitacion) {
            return base.Channel.ObtenerPorHotelYNumeroHabitacion(codigoHotel, numeroHabitacion);
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ObtenerPorHotelYNumeroHabitacionAsync(string codigoHotel, int numeroHabitacion) {
            return base.Channel.ObtenerPorHotelYNumeroHabitacionAsync(codigoHotel, numeroHabitacion);
        }
        
        public Booking.Business.RoomService.Habitacion CrearHabitacion(Booking.Business.RoomService.Habitacion habitacion) {
            return base.Channel.CrearHabitacion(habitacion);
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> CrearHabitacionAsync(Booking.Business.RoomService.Habitacion habitacion) {
            return base.Channel.CrearHabitacionAsync(habitacion);
        }
        
        public Booking.Business.RoomService.Habitacion ModificarHabitacion(Booking.Business.RoomService.Habitacion habitacion) {
            return base.Channel.ModificarHabitacion(habitacion);
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion> ModificarHabitacionAsync(Booking.Business.RoomService.Habitacion habitacion) {
            return base.Channel.ModificarHabitacionAsync(habitacion);
        }
        
        public int EliminarHabitacion(int habitacionId) {
            return base.Channel.EliminarHabitacion(habitacionId);
        }
        
        public System.Threading.Tasks.Task<int> EliminarHabitacionAsync(int habitacionId) {
            return base.Channel.EliminarHabitacionAsync(habitacionId);
        }
        
        public Booking.Business.RoomService.Habitacion[] ListarHabitaciones() {
            return base.Channel.ListarHabitaciones();
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion[]> ListarHabitacionesAsync() {
            return base.Channel.ListarHabitacionesAsync();
        }
        
        public Booking.Business.RoomService.Habitacion[] ListarHabitacionesPorHotel(string codigoHotel) {
            return base.Channel.ListarHabitacionesPorHotel(codigoHotel);
        }
        
        public System.Threading.Tasks.Task<Booking.Business.RoomService.Habitacion[]> ListarHabitacionesPorHotelAsync(string codigoHotel) {
            return base.Channel.ListarHabitacionesPorHotelAsync(codigoHotel);
        }
    }
}
