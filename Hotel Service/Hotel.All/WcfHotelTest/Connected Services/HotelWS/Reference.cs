﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfHotelTest.HotelWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Hotel", Namespace="http://schemas.datacontract.org/2004/07/WcfHotel.Dominio")]
    [System.SerializableAttribute()]
    public partial class Hotel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdHotelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
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
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdHotel {
            get {
                return this.IdHotelField;
            }
            set {
                if ((this.IdHotelField.Equals(value) != true)) {
                    this.IdHotelField = value;
                    this.RaisePropertyChanged("IdHotel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/WcfHotel.Errores")]
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HotelWS.IHotelService")]
    public interface IHotelService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/CrearHotel", ReplyAction="http://tempuri.org/IHotelService/CrearHotelResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WcfHotelTest.HotelWS.RepetidoException), Action="http://tempuri.org/IHotelService/CrearHotelRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/WcfHotel.Errores")]
        WcfHotelTest.HotelWS.Hotel CrearHotel(WcfHotelTest.HotelWS.Hotel hotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/CrearHotel", ReplyAction="http://tempuri.org/IHotelService/CrearHotelResponse")]
        System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> CrearHotelAsync(WcfHotelTest.HotelWS.Hotel hotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ConsultarHotel", ReplyAction="http://tempuri.org/IHotelService/ConsultarHotelResponse")]
        WcfHotelTest.HotelWS.Hotel ConsultarHotel(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ConsultarHotel", ReplyAction="http://tempuri.org/IHotelService/ConsultarHotelResponse")]
        System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> ConsultarHotelAsync(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ModificarHotel", ReplyAction="http://tempuri.org/IHotelService/ModificarHotelResponse")]
        WcfHotelTest.HotelWS.Hotel ModificarHotel(WcfHotelTest.HotelWS.Hotel hotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ModificarHotel", ReplyAction="http://tempuri.org/IHotelService/ModificarHotelResponse")]
        System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> ModificarHotelAsync(WcfHotelTest.HotelWS.Hotel hotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/EliminarHotel", ReplyAction="http://tempuri.org/IHotelService/EliminarHotelResponse")]
        void EliminarHotel(int idHotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/EliminarHotel", ReplyAction="http://tempuri.org/IHotelService/EliminarHotelResponse")]
        System.Threading.Tasks.Task EliminarHotelAsync(int idHotel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ListarHoteles", ReplyAction="http://tempuri.org/IHotelService/ListarHotelesResponse")]
        WcfHotelTest.HotelWS.Hotel[] ListarHoteles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHotelService/ListarHoteles", ReplyAction="http://tempuri.org/IHotelService/ListarHotelesResponse")]
        System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel[]> ListarHotelesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHotelServiceChannel : WcfHotelTest.HotelWS.IHotelService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HotelServiceClient : System.ServiceModel.ClientBase<WcfHotelTest.HotelWS.IHotelService>, WcfHotelTest.HotelWS.IHotelService {
        
        public HotelServiceClient() {
        }
        
        public HotelServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HotelServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HotelServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WcfHotelTest.HotelWS.Hotel CrearHotel(WcfHotelTest.HotelWS.Hotel hotel) {
            return base.Channel.CrearHotel(hotel);
        }
        
        public System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> CrearHotelAsync(WcfHotelTest.HotelWS.Hotel hotel) {
            return base.Channel.CrearHotelAsync(hotel);
        }
        
        public WcfHotelTest.HotelWS.Hotel ConsultarHotel(string nombre) {
            return base.Channel.ConsultarHotel(nombre);
        }
        
        public System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> ConsultarHotelAsync(string nombre) {
            return base.Channel.ConsultarHotelAsync(nombre);
        }
        
        public WcfHotelTest.HotelWS.Hotel ModificarHotel(WcfHotelTest.HotelWS.Hotel hotel) {
            return base.Channel.ModificarHotel(hotel);
        }
        
        public System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel> ModificarHotelAsync(WcfHotelTest.HotelWS.Hotel hotel) {
            return base.Channel.ModificarHotelAsync(hotel);
        }
        
        public void EliminarHotel(int idHotel) {
            base.Channel.EliminarHotel(idHotel);
        }
        
        public System.Threading.Tasks.Task EliminarHotelAsync(int idHotel) {
            return base.Channel.EliminarHotelAsync(idHotel);
        }
        
        public WcfHotelTest.HotelWS.Hotel[] ListarHoteles() {
            return base.Channel.ListarHoteles();
        }
        
        public System.Threading.Tasks.Task<WcfHotelTest.HotelWS.Hotel[]> ListarHotelesAsync() {
            return base.Channel.ListarHotelesAsync();
        }
    }
}