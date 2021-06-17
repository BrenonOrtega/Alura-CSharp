using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {

            var options = new JsonSerializerOptions {AllowTrailingCommas = true, IncludeFields = true, };
            var reading = File.ReadAllText(@"C:\Users\Bryan\Documents\Coding\Projects\CSharp\SchoolApp\SchoolApp.Application\JsonDb.Json");
            var test = JsonSerializer.Deserialize<IEnumerable<Student>>(reading, options);
        }
    }
    public class Student {
        int Id { get; set; }
        public Name FirstName {get; set;}
        public Name LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Email Email { get; set; }
        //public IList<Course> Courses { get; set; }
        public override string ToString() => $"ID: { Id } - Name: { FirstName } { LastName } - Birth Date: { BirthDate }.";    
    }

 
    public class Name : JsonConverter<string>{
        private string _text;
        public Name()
        {
            
        }
        public Name(string text) {
            if (string.IsNullOrWhiteSpace(text))
                throw new Exception($"field { nameof(Name) } is required. ");
            _text = text;
        }

        public static implicit operator Name(string text) => new Name(text);
        public static implicit operator string(Name name) => name._text;

        public override bool Equals(object obj) {
            var areEquals =  obj is string text && this._text == text
                            || obj is Name name && this._text == name._text
                            || ReferenceEquals(obj, this)
                            ;
            return areEquals;
        }
        public override int GetHashCode() => _text.GetHashCode();
        public override string ToString() => _text;

        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return this._text ;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            _text = new Name(value);
        }
    }

    public class StringConverter : JsonConverter<Name>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return this;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
             new Name(value);
        }
    }

    public class Email
    {
        private string _text;

        public Email()
        {
        }

        public Email(string address)
        {
            ThrowIfInvalid(address);
            _text = address;
        }

        public static implicit operator Email(string text) => new Email(text);

        public static implicit operator string(Email email) => email._text;

        private static void ThrowIfInvalid(string text)
        {
            ThrowIfNullOrEmpty(text);
            ThrowIfFormatDoesntMatch(text);
        }

        public override string ToString() => _text.ToString();

        public override int GetHashCode() => _text.GetHashCode();

        public override bool Equals(object obj)
        {
            var areEquals =  obj is string text && this._text == text
                            || obj is Email email && this._text == email._text
                            || ReferenceEquals(obj, this)
                            ;
            return areEquals;
        }

        private static void ThrowIfNullOrEmpty(string text)
        {
            if(String.IsNullOrEmpty(text))
                throw new Exception("Email cannot be empty.");
        }

        private static void ThrowIfFormatDoesntMatch(string text)
        {
            var pattern = @"^[a-z0-9.]+@[a-z0-9.]+.(com|net|io){1}";
            var re = new Regex(pattern);

            if(re.IsMatch(text) != true)
                throw new Exception("Invalid email format.");
        }
    }
}
