// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: net/net_protocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Spire.Protocol.Net {

  /// <summary>Holder for reflection information generated from net/net_protocol.proto</summary>
  public static partial class NetProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for net/net_protocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NetProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZuZXQvbmV0X3Byb3RvY29sLnByb3RvEhJzcGlyZS5wcm90b2NvbC5uZXQa",
            "E25ldC9oZWFydGJlYXQucHJvdG8aDm5ldC9waW5nLnByb3RvGhduZXQvcm9v",
            "bV90cmFuc2Zlci5wcm90byK3AgoRTmV0Q2xpZW50UHJvdG9jb2wSKAoEcGlu",
            "ZxgBIAEoCzIYLnNwaXJlLnByb3RvY29sLm5ldC5QaW5nSAASKAoEcG9uZxgC",
            "IAEoCzIYLnNwaXJlLnByb3RvY29sLm5ldC5Qb25nSAASMgoJaGVhcnRiZWF0",
            "GAMgASgLMh0uc3BpcmUucHJvdG9jb2wubmV0LkhlYXJ0YmVhdEgAEkgKFXJv",
            "b21fdHJhbnNmZXJfcmVxdWVzdBgJIAEoCzInLnNwaXJlLnByb3RvY29sLm5l",
            "dC5Sb29tVHJhbnNmZXJSZXF1ZXN0SAASRAoTcm9vbV90cmFuc2Zlcl9yZWFk",
            "eRgKIAEoCzIlLnNwaXJlLnByb3RvY29sLm5ldC5Sb29tVHJhbnNmZXJSZWFk",
            "eUgAQgoKCHByb3RvY29sIsYCChFOZXRTZXJ2ZXJQcm90b2NvbBIoCgRwaW5n",
            "GAEgASgLMhguc3BpcmUucHJvdG9jb2wubmV0LlBpbmdIABIoCgRwb25nGAIg",
            "ASgLMhguc3BpcmUucHJvdG9jb2wubmV0LlBvbmdIABIyCgloZWFydGJlYXQY",
            "AyABKAsyHS5zcGlyZS5wcm90b2NvbC5uZXQuSGVhcnRiZWF0SAASVQoccm9v",
            "bV90cmFuc2Zlcl9yZXF1ZXN0X3Jlc3VsdBgJIAEoCzItLnNwaXJlLnByb3Rv",
            "Y29sLm5ldC5Sb29tVHJhbnNmZXJSZXF1ZXN0UmVzdWx0SAASRgoUcm9vbV90",
            "cmFuc2Zlcl9jb21taXQYCiABKAsyJi5zcGlyZS5wcm90b2NvbC5uZXQuUm9v",
            "bVRyYW5zZmVyQ29tbWl0SABCCgoIcHJvdG9jb2xiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Spire.Protocol.Net.HeartbeatReflection.Descriptor, global::Spire.Protocol.Net.PingReflection.Descriptor, global::Spire.Protocol.Net.RoomTransferReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Spire.Protocol.Net.NetClientProtocol), global::Spire.Protocol.Net.NetClientProtocol.Parser, new[]{ "Ping", "Pong", "Heartbeat", "RoomTransferRequest", "RoomTransferReady" }, new[]{ "Protocol" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Spire.Protocol.Net.NetServerProtocol), global::Spire.Protocol.Net.NetServerProtocol.Parser, new[]{ "Ping", "Pong", "Heartbeat", "RoomTransferRequestResult", "RoomTransferCommit" }, new[]{ "Protocol" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class NetClientProtocol : pb::IMessage<NetClientProtocol>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<NetClientProtocol> _parser = new pb::MessageParser<NetClientProtocol>(() => new NetClientProtocol());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NetClientProtocol> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Spire.Protocol.Net.NetProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetClientProtocol() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetClientProtocol(NetClientProtocol other) : this() {
      switch (other.ProtocolCase) {
        case ProtocolOneofCase.Ping:
          Ping = other.Ping.Clone();
          break;
        case ProtocolOneofCase.Pong:
          Pong = other.Pong.Clone();
          break;
        case ProtocolOneofCase.Heartbeat:
          Heartbeat = other.Heartbeat.Clone();
          break;
        case ProtocolOneofCase.RoomTransferRequest:
          RoomTransferRequest = other.RoomTransferRequest.Clone();
          break;
        case ProtocolOneofCase.RoomTransferReady:
          RoomTransferReady = other.RoomTransferReady.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetClientProtocol Clone() {
      return new NetClientProtocol(this);
    }

    /// <summary>Field number for the "ping" field.</summary>
    public const int PingFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Ping Ping {
      get { return protocolCase_ == ProtocolOneofCase.Ping ? (global::Spire.Protocol.Net.Ping) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Ping;
      }
    }

    /// <summary>Field number for the "pong" field.</summary>
    public const int PongFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Pong Pong {
      get { return protocolCase_ == ProtocolOneofCase.Pong ? (global::Spire.Protocol.Net.Pong) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Pong;
      }
    }

    /// <summary>Field number for the "heartbeat" field.</summary>
    public const int HeartbeatFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Heartbeat Heartbeat {
      get { return protocolCase_ == ProtocolOneofCase.Heartbeat ? (global::Spire.Protocol.Net.Heartbeat) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Heartbeat;
      }
    }

    /// <summary>Field number for the "room_transfer_request" field.</summary>
    public const int RoomTransferRequestFieldNumber = 9;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.RoomTransferRequest RoomTransferRequest {
      get { return protocolCase_ == ProtocolOneofCase.RoomTransferRequest ? (global::Spire.Protocol.Net.RoomTransferRequest) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.RoomTransferRequest;
      }
    }

    /// <summary>Field number for the "room_transfer_ready" field.</summary>
    public const int RoomTransferReadyFieldNumber = 10;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.RoomTransferReady RoomTransferReady {
      get { return protocolCase_ == ProtocolOneofCase.RoomTransferReady ? (global::Spire.Protocol.Net.RoomTransferReady) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.RoomTransferReady;
      }
    }

    private object protocol_;
    /// <summary>Enum of possible cases for the "protocol" oneof.</summary>
    public enum ProtocolOneofCase {
      None = 0,
      Ping = 1,
      Pong = 2,
      Heartbeat = 3,
      RoomTransferRequest = 9,
      RoomTransferReady = 10,
    }
    private ProtocolOneofCase protocolCase_ = ProtocolOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtocolOneofCase ProtocolCase {
      get { return protocolCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearProtocol() {
      protocolCase_ = ProtocolOneofCase.None;
      protocol_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as NetClientProtocol);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NetClientProtocol other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Ping, other.Ping)) return false;
      if (!object.Equals(Pong, other.Pong)) return false;
      if (!object.Equals(Heartbeat, other.Heartbeat)) return false;
      if (!object.Equals(RoomTransferRequest, other.RoomTransferRequest)) return false;
      if (!object.Equals(RoomTransferReady, other.RoomTransferReady)) return false;
      if (ProtocolCase != other.ProtocolCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (protocolCase_ == ProtocolOneofCase.Ping) hash ^= Ping.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.Pong) hash ^= Pong.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) hash ^= Heartbeat.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) hash ^= RoomTransferRequest.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) hash ^= RoomTransferReady.GetHashCode();
      hash ^= (int) protocolCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        output.WriteRawTag(10);
        output.WriteMessage(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        output.WriteRawTag(18);
        output.WriteMessage(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        output.WriteRawTag(26);
        output.WriteMessage(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) {
        output.WriteRawTag(74);
        output.WriteMessage(RoomTransferRequest);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) {
        output.WriteRawTag(82);
        output.WriteMessage(RoomTransferReady);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        output.WriteRawTag(10);
        output.WriteMessage(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        output.WriteRawTag(18);
        output.WriteMessage(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        output.WriteRawTag(26);
        output.WriteMessage(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) {
        output.WriteRawTag(74);
        output.WriteMessage(RoomTransferRequest);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) {
        output.WriteRawTag(82);
        output.WriteMessage(RoomTransferReady);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RoomTransferRequest);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RoomTransferReady);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NetClientProtocol other) {
      if (other == null) {
        return;
      }
      switch (other.ProtocolCase) {
        case ProtocolOneofCase.Ping:
          if (Ping == null) {
            Ping = new global::Spire.Protocol.Net.Ping();
          }
          Ping.MergeFrom(other.Ping);
          break;
        case ProtocolOneofCase.Pong:
          if (Pong == null) {
            Pong = new global::Spire.Protocol.Net.Pong();
          }
          Pong.MergeFrom(other.Pong);
          break;
        case ProtocolOneofCase.Heartbeat:
          if (Heartbeat == null) {
            Heartbeat = new global::Spire.Protocol.Net.Heartbeat();
          }
          Heartbeat.MergeFrom(other.Heartbeat);
          break;
        case ProtocolOneofCase.RoomTransferRequest:
          if (RoomTransferRequest == null) {
            RoomTransferRequest = new global::Spire.Protocol.Net.RoomTransferRequest();
          }
          RoomTransferRequest.MergeFrom(other.RoomTransferRequest);
          break;
        case ProtocolOneofCase.RoomTransferReady:
          if (RoomTransferReady == null) {
            RoomTransferReady = new global::Spire.Protocol.Net.RoomTransferReady();
          }
          RoomTransferReady.MergeFrom(other.RoomTransferReady);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::Spire.Protocol.Net.Ping subBuilder = new global::Spire.Protocol.Net.Ping();
            if (protocolCase_ == ProtocolOneofCase.Ping) {
              subBuilder.MergeFrom(Ping);
            }
            input.ReadMessage(subBuilder);
            Ping = subBuilder;
            break;
          }
          case 18: {
            global::Spire.Protocol.Net.Pong subBuilder = new global::Spire.Protocol.Net.Pong();
            if (protocolCase_ == ProtocolOneofCase.Pong) {
              subBuilder.MergeFrom(Pong);
            }
            input.ReadMessage(subBuilder);
            Pong = subBuilder;
            break;
          }
          case 26: {
            global::Spire.Protocol.Net.Heartbeat subBuilder = new global::Spire.Protocol.Net.Heartbeat();
            if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
              subBuilder.MergeFrom(Heartbeat);
            }
            input.ReadMessage(subBuilder);
            Heartbeat = subBuilder;
            break;
          }
          case 74: {
            global::Spire.Protocol.Net.RoomTransferRequest subBuilder = new global::Spire.Protocol.Net.RoomTransferRequest();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) {
              subBuilder.MergeFrom(RoomTransferRequest);
            }
            input.ReadMessage(subBuilder);
            RoomTransferRequest = subBuilder;
            break;
          }
          case 82: {
            global::Spire.Protocol.Net.RoomTransferReady subBuilder = new global::Spire.Protocol.Net.RoomTransferReady();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) {
              subBuilder.MergeFrom(RoomTransferReady);
            }
            input.ReadMessage(subBuilder);
            RoomTransferReady = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            global::Spire.Protocol.Net.Ping subBuilder = new global::Spire.Protocol.Net.Ping();
            if (protocolCase_ == ProtocolOneofCase.Ping) {
              subBuilder.MergeFrom(Ping);
            }
            input.ReadMessage(subBuilder);
            Ping = subBuilder;
            break;
          }
          case 18: {
            global::Spire.Protocol.Net.Pong subBuilder = new global::Spire.Protocol.Net.Pong();
            if (protocolCase_ == ProtocolOneofCase.Pong) {
              subBuilder.MergeFrom(Pong);
            }
            input.ReadMessage(subBuilder);
            Pong = subBuilder;
            break;
          }
          case 26: {
            global::Spire.Protocol.Net.Heartbeat subBuilder = new global::Spire.Protocol.Net.Heartbeat();
            if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
              subBuilder.MergeFrom(Heartbeat);
            }
            input.ReadMessage(subBuilder);
            Heartbeat = subBuilder;
            break;
          }
          case 74: {
            global::Spire.Protocol.Net.RoomTransferRequest subBuilder = new global::Spire.Protocol.Net.RoomTransferRequest();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferRequest) {
              subBuilder.MergeFrom(RoomTransferRequest);
            }
            input.ReadMessage(subBuilder);
            RoomTransferRequest = subBuilder;
            break;
          }
          case 82: {
            global::Spire.Protocol.Net.RoomTransferReady subBuilder = new global::Spire.Protocol.Net.RoomTransferReady();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferReady) {
              subBuilder.MergeFrom(RoomTransferReady);
            }
            input.ReadMessage(subBuilder);
            RoomTransferReady = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class NetServerProtocol : pb::IMessage<NetServerProtocol>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<NetServerProtocol> _parser = new pb::MessageParser<NetServerProtocol>(() => new NetServerProtocol());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NetServerProtocol> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Spire.Protocol.Net.NetProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetServerProtocol() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetServerProtocol(NetServerProtocol other) : this() {
      switch (other.ProtocolCase) {
        case ProtocolOneofCase.Ping:
          Ping = other.Ping.Clone();
          break;
        case ProtocolOneofCase.Pong:
          Pong = other.Pong.Clone();
          break;
        case ProtocolOneofCase.Heartbeat:
          Heartbeat = other.Heartbeat.Clone();
          break;
        case ProtocolOneofCase.RoomTransferRequestResult:
          RoomTransferRequestResult = other.RoomTransferRequestResult.Clone();
          break;
        case ProtocolOneofCase.RoomTransferCommit:
          RoomTransferCommit = other.RoomTransferCommit.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NetServerProtocol Clone() {
      return new NetServerProtocol(this);
    }

    /// <summary>Field number for the "ping" field.</summary>
    public const int PingFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Ping Ping {
      get { return protocolCase_ == ProtocolOneofCase.Ping ? (global::Spire.Protocol.Net.Ping) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Ping;
      }
    }

    /// <summary>Field number for the "pong" field.</summary>
    public const int PongFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Pong Pong {
      get { return protocolCase_ == ProtocolOneofCase.Pong ? (global::Spire.Protocol.Net.Pong) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Pong;
      }
    }

    /// <summary>Field number for the "heartbeat" field.</summary>
    public const int HeartbeatFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.Heartbeat Heartbeat {
      get { return protocolCase_ == ProtocolOneofCase.Heartbeat ? (global::Spire.Protocol.Net.Heartbeat) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.Heartbeat;
      }
    }

    /// <summary>Field number for the "room_transfer_request_result" field.</summary>
    public const int RoomTransferRequestResultFieldNumber = 9;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.RoomTransferRequestResult RoomTransferRequestResult {
      get { return protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult ? (global::Spire.Protocol.Net.RoomTransferRequestResult) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.RoomTransferRequestResult;
      }
    }

    /// <summary>Field number for the "room_transfer_commit" field.</summary>
    public const int RoomTransferCommitFieldNumber = 10;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Spire.Protocol.Net.RoomTransferCommit RoomTransferCommit {
      get { return protocolCase_ == ProtocolOneofCase.RoomTransferCommit ? (global::Spire.Protocol.Net.RoomTransferCommit) protocol_ : null; }
      set {
        protocol_ = value;
        protocolCase_ = value == null ? ProtocolOneofCase.None : ProtocolOneofCase.RoomTransferCommit;
      }
    }

    private object protocol_;
    /// <summary>Enum of possible cases for the "protocol" oneof.</summary>
    public enum ProtocolOneofCase {
      None = 0,
      Ping = 1,
      Pong = 2,
      Heartbeat = 3,
      RoomTransferRequestResult = 9,
      RoomTransferCommit = 10,
    }
    private ProtocolOneofCase protocolCase_ = ProtocolOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ProtocolOneofCase ProtocolCase {
      get { return protocolCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearProtocol() {
      protocolCase_ = ProtocolOneofCase.None;
      protocol_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as NetServerProtocol);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NetServerProtocol other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Ping, other.Ping)) return false;
      if (!object.Equals(Pong, other.Pong)) return false;
      if (!object.Equals(Heartbeat, other.Heartbeat)) return false;
      if (!object.Equals(RoomTransferRequestResult, other.RoomTransferRequestResult)) return false;
      if (!object.Equals(RoomTransferCommit, other.RoomTransferCommit)) return false;
      if (ProtocolCase != other.ProtocolCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (protocolCase_ == ProtocolOneofCase.Ping) hash ^= Ping.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.Pong) hash ^= Pong.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) hash ^= Heartbeat.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) hash ^= RoomTransferRequestResult.GetHashCode();
      if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) hash ^= RoomTransferCommit.GetHashCode();
      hash ^= (int) protocolCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        output.WriteRawTag(10);
        output.WriteMessage(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        output.WriteRawTag(18);
        output.WriteMessage(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        output.WriteRawTag(26);
        output.WriteMessage(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) {
        output.WriteRawTag(74);
        output.WriteMessage(RoomTransferRequestResult);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) {
        output.WriteRawTag(82);
        output.WriteMessage(RoomTransferCommit);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        output.WriteRawTag(10);
        output.WriteMessage(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        output.WriteRawTag(18);
        output.WriteMessage(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        output.WriteRawTag(26);
        output.WriteMessage(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) {
        output.WriteRawTag(74);
        output.WriteMessage(RoomTransferRequestResult);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) {
        output.WriteRawTag(82);
        output.WriteMessage(RoomTransferCommit);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (protocolCase_ == ProtocolOneofCase.Ping) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Ping);
      }
      if (protocolCase_ == ProtocolOneofCase.Pong) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Pong);
      }
      if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Heartbeat);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RoomTransferRequestResult);
      }
      if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RoomTransferCommit);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NetServerProtocol other) {
      if (other == null) {
        return;
      }
      switch (other.ProtocolCase) {
        case ProtocolOneofCase.Ping:
          if (Ping == null) {
            Ping = new global::Spire.Protocol.Net.Ping();
          }
          Ping.MergeFrom(other.Ping);
          break;
        case ProtocolOneofCase.Pong:
          if (Pong == null) {
            Pong = new global::Spire.Protocol.Net.Pong();
          }
          Pong.MergeFrom(other.Pong);
          break;
        case ProtocolOneofCase.Heartbeat:
          if (Heartbeat == null) {
            Heartbeat = new global::Spire.Protocol.Net.Heartbeat();
          }
          Heartbeat.MergeFrom(other.Heartbeat);
          break;
        case ProtocolOneofCase.RoomTransferRequestResult:
          if (RoomTransferRequestResult == null) {
            RoomTransferRequestResult = new global::Spire.Protocol.Net.RoomTransferRequestResult();
          }
          RoomTransferRequestResult.MergeFrom(other.RoomTransferRequestResult);
          break;
        case ProtocolOneofCase.RoomTransferCommit:
          if (RoomTransferCommit == null) {
            RoomTransferCommit = new global::Spire.Protocol.Net.RoomTransferCommit();
          }
          RoomTransferCommit.MergeFrom(other.RoomTransferCommit);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::Spire.Protocol.Net.Ping subBuilder = new global::Spire.Protocol.Net.Ping();
            if (protocolCase_ == ProtocolOneofCase.Ping) {
              subBuilder.MergeFrom(Ping);
            }
            input.ReadMessage(subBuilder);
            Ping = subBuilder;
            break;
          }
          case 18: {
            global::Spire.Protocol.Net.Pong subBuilder = new global::Spire.Protocol.Net.Pong();
            if (protocolCase_ == ProtocolOneofCase.Pong) {
              subBuilder.MergeFrom(Pong);
            }
            input.ReadMessage(subBuilder);
            Pong = subBuilder;
            break;
          }
          case 26: {
            global::Spire.Protocol.Net.Heartbeat subBuilder = new global::Spire.Protocol.Net.Heartbeat();
            if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
              subBuilder.MergeFrom(Heartbeat);
            }
            input.ReadMessage(subBuilder);
            Heartbeat = subBuilder;
            break;
          }
          case 74: {
            global::Spire.Protocol.Net.RoomTransferRequestResult subBuilder = new global::Spire.Protocol.Net.RoomTransferRequestResult();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) {
              subBuilder.MergeFrom(RoomTransferRequestResult);
            }
            input.ReadMessage(subBuilder);
            RoomTransferRequestResult = subBuilder;
            break;
          }
          case 82: {
            global::Spire.Protocol.Net.RoomTransferCommit subBuilder = new global::Spire.Protocol.Net.RoomTransferCommit();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) {
              subBuilder.MergeFrom(RoomTransferCommit);
            }
            input.ReadMessage(subBuilder);
            RoomTransferCommit = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            global::Spire.Protocol.Net.Ping subBuilder = new global::Spire.Protocol.Net.Ping();
            if (protocolCase_ == ProtocolOneofCase.Ping) {
              subBuilder.MergeFrom(Ping);
            }
            input.ReadMessage(subBuilder);
            Ping = subBuilder;
            break;
          }
          case 18: {
            global::Spire.Protocol.Net.Pong subBuilder = new global::Spire.Protocol.Net.Pong();
            if (protocolCase_ == ProtocolOneofCase.Pong) {
              subBuilder.MergeFrom(Pong);
            }
            input.ReadMessage(subBuilder);
            Pong = subBuilder;
            break;
          }
          case 26: {
            global::Spire.Protocol.Net.Heartbeat subBuilder = new global::Spire.Protocol.Net.Heartbeat();
            if (protocolCase_ == ProtocolOneofCase.Heartbeat) {
              subBuilder.MergeFrom(Heartbeat);
            }
            input.ReadMessage(subBuilder);
            Heartbeat = subBuilder;
            break;
          }
          case 74: {
            global::Spire.Protocol.Net.RoomTransferRequestResult subBuilder = new global::Spire.Protocol.Net.RoomTransferRequestResult();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferRequestResult) {
              subBuilder.MergeFrom(RoomTransferRequestResult);
            }
            input.ReadMessage(subBuilder);
            RoomTransferRequestResult = subBuilder;
            break;
          }
          case 82: {
            global::Spire.Protocol.Net.RoomTransferCommit subBuilder = new global::Spire.Protocol.Net.RoomTransferCommit();
            if (protocolCase_ == ProtocolOneofCase.RoomTransferCommit) {
              subBuilder.MergeFrom(RoomTransferCommit);
            }
            input.ReadMessage(subBuilder);
            RoomTransferCommit = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
