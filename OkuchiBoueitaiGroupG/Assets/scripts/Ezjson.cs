
using System;
using System.Collections.Generic;
using System.IO;

public class EzjsonObject{
	public Dictionary< String, Object > member{ private set; get; }
	public EzjsonObject( ){
		member = new Dictionary< String, Object >( );
	}
}


public class Ezjson{
	public List< EzjsonObject > objects{ protected set; get; }
	private Ezjson( List< EzjsonObject > objects ){
		this.objects = objects;
	}
	
	public static Ezjson Load( String filename ){
		if( !filename.EndsWith(".ezjson") )  return null;
		if( !File.Exists(filename) ) return null;
		
		List< EzjsonObject > objects = new List< EzjsonObject >();
		StreamReader reader = new StreamReader( filename );
		while( !reader.EndOfStream ){
			String line = reader.ReadLine( );
			if( line.Contains("#") ){
				int commentStart = line.IndexOf( '#' );
				line = line.Substring( 0, commentStart );
			}
			if( line.Length == 0 ) continue;
			line = line.Trim( ' ' );
			char[] keys = {'{', '}'};
			line = line.Trim( keys );
			String[] members = line.Split( ',' );
			EzjsonObject obj = new EzjsonObject( );
			foreach( String s in members ){
				String[] elem = s.Split( ':' );
				String key = Value.Resolve( elem[0].Trim() ).ToString( );
				Object val = Value.Resolve( elem[1].Trim() );
				obj.member.Add( key, val );
			}
			objects.Add( obj );
		}
		return new Ezjson( objects );
	}
	
	public override string ToString( ) {
		String ret = "";
		foreach( EzjsonObject obj in objects ){
			ret += "------Object--------\n";
			foreach( KeyValuePair<String,Object> member in obj.member ){
				ret += member.Key + " : " + member.Value.ToString() + "\n";
			}
		}
		return ret;
	}
}

class Value{
	public static Object Resolve( String val ){
		if( val.Equals("null") ) return null;
		if (val.Contains("\"")) return val.Trim('\"');
		if (val.Contains(".")) return Single.Parse(val);
		if( val.Equals("true") ) return (Object)true;
		if( val.Equals("false") ) return (Object)false;
		return Int32.Parse(val);
	}
}
