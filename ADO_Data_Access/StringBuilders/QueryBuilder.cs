using Domain.ModelPOCO;
using System.Collections;
using System.Collections.Immutable;
using System.Text;

namespace ADO_Data_Access.StringBuilders
{
    /*InitializeTableChemaName() -> */
    public class QueryBuilder
	{
		private StringBuilder query = new StringBuilder();
		private List<string> selectColumns = new List<string>();
		private List<object> parameters = new List<object>();
		private string fromTable;
		private List<string> joins = new List<string>();
		private List<string> whereConditions = new List<string>();
		private string orderBy;
		private int? limit;
		private int? offset;
		private bool isInitialized = false;

		public bool IsInitialized { get =>  isInitialized; }
		public List<object> Parameters { get => parameters; }

		private static readonly ImmutableDictionary<string, string> tableSchemaName = InitializeTableSchemaDictionary();

		private static ImmutableDictionary<string, string> InitializeTableSchemaDictionary()
		{
		   return new Dictionary<string, string>
		   {
			   { $"{nameof(Book)}, ","SoleSchema"}
		   }.ToImmutableDictionary();
		}

        public static ImmutableDictionary<string, string> TableSchemaName => tableSchemaName;

		private static readonly ImmutableDictionary<string, string> classTableDictionary = InitializeClassTableDictionary();

		private static ImmutableDictionary<string, string> InitializeClassTableDictionary()
		{
			return new Dictionary<string, string>
			{
				/*
				{ $"{nameof(StorableObjectEvent)}", "\"event\"" },
				{ $"{nameof(AdditionEvent)}", "addition" },
				{ $"{nameof(SentEvent)}", "delivery" },
				{ $"{nameof(ArrivedEvent)}", "delivery" },
				{ $"{nameof(ReservedEvent)}", "reservation" },
				{ $"{nameof(ReserveEndedEvent)}", "reservation" },
				{ $"{nameof(DecomissionedEvent)}", "decomission" },
                { $"{nameof(DataChangedEvent)}", "data_changed" },*/
                { $"{nameof(Employee)}", "employee" },
			}.ToImmutableDictionary();
		}

		public static ImmutableDictionary<string, string> ClassTableName => classTableDictionary;

		private static readonly ImmutableDictionary<string, string> propertyColumnDictionary = InitializePropertyColumnDictionary();

		private static ImmutableDictionary<string, string> InitializePropertyColumnDictionary()
		{
			return new Dictionary<string, string>
			{
                { $"{nameof(Book)}.{nameof(Book.Cipher)}", $"{ClassTableName[nameof(Book)]}.sypher" },
                { $"{nameof(Book)}.{nameof(Book.Title)}", $"{ClassTableName[nameof(Book)]}.title" },
                { $"{nameof(Book)}.{nameof(Book.Author)}", $"{ClassTableName[nameof(Book)]}.author" },
                { $"{nameof(Book)}.{nameof(Book.Genre)}", $"{ClassTableName[nameof(Book)]}.book_genre" },
                { $"{nameof(Book)}.{nameof(Book.Publisher)}", $"{ClassTableName[nameof(Book)]}.publisher" },
                { $"{nameof(Book)}.{nameof(Book.DateOfPublishing)}", $"{ClassTableName[nameof(Book)]}.date_of_publishing" },
                { $"{nameof(Book)}.{nameof(Book.Amount)}", $"{ClassTableName[nameof(Book)]}.amount" },



                { $"{nameof(BookToken)}.{nameof(BookToken.TokenId)}", $"{ClassTableName[nameof(BookToken)]}.token_id" },
                { $"{nameof(BookToken)}.{nameof(BookToken.TokenCipher)}", $"{ClassTableName[nameof(BookToken)]}.sypher" },
                { $"{nameof(BookToken)}.{nameof(BookToken.RoomNumber)}", $"{ClassTableName[nameof(BookToken)]}.room_no" },
                { $"{nameof(BookToken)}.{nameof(BookToken.IsTaken)}", $"{ClassTableName[nameof(BookToken)]}.taken" },


                { $"{nameof(BookLease)}.{nameof(BookLease.TokenId)}", $"{ClassTableName[nameof(BookLease)]}.token_id" },
                { $"{nameof(BookLease)}.{nameof(BookLease.LesseeId)}", $"{ClassTableName[nameof(BookLease)]}.lessee_id" },
                { $"{nameof(BookLease)}.{nameof(BookLease.DateOfInitiation)}", $"{ClassTableName[nameof(BookLease)]}.date_of_initiation" },
                { $"{nameof(BookLease)}.{nameof(BookLease.DateOfClosure)}", $"{ClassTableName[nameof(BookLease)]}.date_of_closure" },
                { $"{nameof(BookLease)}.{nameof(BookLease.FactualDateOfClosure)}", $"{ClassTableName[nameof(BookLease)]}.date_of_closure_fact" },
                { $"{nameof(BookLease)}.{nameof(BookLease.SumOfFine)}", $"{ClassTableName[nameof(BookLease)]}.sum_of_fine" },
                { $"{nameof(BookLease)}.{nameof(BookLease.ResponsibleEmployee)}", $"{ClassTableName[nameof(BookLease)]}.responsible_employee_id" },


                { $"{nameof(Member)}.{nameof(Member.MemberId)}", $"{ClassTableName[nameof(Member)]}.member_id_no" },
                { $"{nameof(Member)}.{nameof(Member.PassportNumber)}", $"{ClassTableName[nameof(Member)]}.passport_no" },
                { $"{nameof(Member)}.{nameof(Member.Birthdate)}", $"{ClassTableName[nameof(Member)]}.birth_date" },
                { $"{nameof(Member)}.{nameof(Member.Address)}", $"{ClassTableName[nameof(Member)]}.address" },
                { $"{nameof(Member)}.{nameof(Member.TelephoneNumber)}", $"{ClassTableName[nameof(Member)]}.telephone_no" },
                { $"{nameof(Member)}.{nameof(Member.Education)}", $"{ClassTableName[nameof(Member)]}.education" },
                { $"{nameof(Member)}.{nameof(Member.ReadingRoomNumber)}", $"{ClassTableName[nameof(Member)]}.reading_room_number" },
                { $"{nameof(Member)}.{nameof(Member.Photo)}", $"{ClassTableName[nameof(Member)]}.photo" },
                { $"{nameof(Member)}.{nameof(Member.FullName)}", $"{ClassTableName[nameof(Member)]}.fullname" },


                { $"{nameof(ReadingRoom)}.{nameof(ReadingRoom.RoomNumber)}", $"{ClassTableName[nameof(ReadingRoom)]}.room_no" },
                { $"{nameof(ReadingRoom)}.{nameof(ReadingRoom.Name)}", $"{ClassTableName[nameof(ReadingRoom)]}.room_name" },
                { $"{nameof(ReadingRoom)}.{nameof(ReadingRoom.Capacity)}", $"{ClassTableName[nameof(ReadingRoom)]}.capacity" },


                { $"{nameof(Employee)}.{nameof(Employee.PassportNumber)}", $"{ClassTableName[nameof(Employee)]}.passport_no" },
				{ $"{nameof(Employee)}.{nameof(Employee.FullName)}", $"{ClassTableName[nameof(Employee)]}.fullname" },
				{ $"{nameof(Employee)}.{nameof(Employee.TaxpayerId)}", $"{ClassTableName[nameof(Employee)]}.taxpayer_id" },
				{ $"{nameof(Employee)}.{nameof(Employee.SocialSecurityNumber)}", $"{ClassTableName[nameof(Employee)]}.social_security_no" },
                { $"{nameof(Employee)}.{nameof(Employee.EmployeeSex)}", $"{ClassTableName[nameof(Employee)]}.employee_sex" },
                { $"{nameof(Employee)}.{nameof(Employee.Photo)}", $"{ClassTableName[nameof(Employee)]}.photo" }
            }.ToImmutableDictionary();
		}

		public static ImmutableDictionary<string, string> PropertyToColumnName => propertyColumnDictionary;
		/*
		public static string ToColumnName(string fullpropertyName)
		{
			return $"{nameof(DecomissionedEvent)}.{nameof(DecomissionedEvent.Id)}";
		}
		*/
		public QueryBuilder Select(string[] columns)
		{
			selectColumns.AddRange(columns);
			return this;
		}

		public QueryBuilder From(string table)
		{
			fromTable = table;
			return this;
		}

		public QueryBuilder Join(string table, string condition)
		{
			joins.Add($"JOIN {table} ON {condition}");
			return this;
		}

		public QueryBuilder LeftJoin(string table, string condition)
		{
			joins.Add($"LEFT JOIN {table} ON {condition}");
			return this;
		}

		private string GenerateWhereCondition(string propertyName, string comparison, object? value)
		{
			CheckConditionCorrectnes(propertyName, comparison, value);

			if (value == null)
			{
                return $"{PropertyToColumnName[propertyName]} {comparison} NULL";
            }
			else
			if (value is IEnumerable enumerableValue && value is not string)
			{
				if (!value.GetType().IsArray)
				{
					throw new ArgumentException("Use Array as parametr in query");
				}
				parameters.Add(enumerableValue);
				return $"{PropertyToColumnName[propertyName]} = ANY(@{parameters.Count - 1})";
			}
			else
			{
				parameters.Add(value);
				return $"{PropertyToColumnName[propertyName]} {comparison} @{parameters.Count - 1}";
			}
		}

		public QueryBuilder Where(string propertyName, string comparison, object? value)
		{
			
			if (whereConditions.Count > 0)
			{
				whereConditions.Add($"AND {GenerateWhereCondition(propertyName, comparison, value)}");
			}
			else
			{
				whereConditions.Add(GenerateWhereCondition(propertyName, comparison, value));
			}

			return this;
		}

		public QueryBuilder OrWhere(string propertyName, string comparison, object? value)
		{
			if (whereConditions.Count > 0)
			{
				whereConditions.Add($"OR {GenerateWhereCondition(propertyName, comparison, value)}");
			}
			else
			{
				whereConditions.Add(GenerateWhereCondition(propertyName, comparison, value));
			}

			return this;
		}

		private void CheckConditionCorrectnes(string propertyName, string comparison, object? value)
		{
			if (!IsComparisonOperatorValid(comparison))
			{
				throw new ArgumentException("Invalid comparison operator", nameof(comparison));
			}

			if (comparison != "=" && value is IEnumerable)
			{
                throw new ArgumentException("If value is collection use ANY or =", nameof(value));
            }

			if (comparison == "LIKE" && value is not string)
			{
				throw new ArgumentException("Value must be a string for LIKE operator", nameof(value));
			}

			if (comparison != "IS" && comparison != "IS NOT" && value is null)
			{
				throw new ArgumentException("Invalid comparison operator for NULL value", nameof(comparison));
			}

			if ((comparison == "IS" || comparison == "IS NOT") && value is not null)
			{
				throw new ArgumentException("Value is not null for NULL comparison", nameof(comparison));
			}
		}

		private static readonly HashSet<string> validComparisonOperators = new HashSet<string>
		{
			"=", "!=", "<", ">", "<=", ">=", "LIKE", "IS", "IS NOT", "ANY"
		};

		private bool IsComparisonOperatorValid(string comparison)
		{
			return validComparisonOperators.Contains(comparison);
		}

		public QueryBuilder OrderBy(string propertyName, bool descending = false)
		{
			orderBy = $"ORDER BY {PropertyToColumnName[propertyName]} {(descending ? "DESC" : "ASC")}";
			return this;
		}

		public QueryBuilder Limit(int limit)
		{
			this.limit = limit;
			return this;
		}

		public QueryBuilder Offset(int offset)
		{
			this.offset = offset;
			return this;
		}

		public string Build()
		{
			if (!selectColumns.Any())
			{
				throw new InvalidOperationException("No columns specified for SELECT.");
			}

			query.Append($"SELECT {string.Join(", ", selectColumns)} FROM {fromTable}");

			if (joins.Any())
			{
				query.Append($" {string.Join(" ", joins)}");
			}

			if (whereConditions.Any())
			{
				query.Append($" WHERE {string.Join(" ", whereConditions)}");
			}

			if (!string.IsNullOrEmpty(orderBy))
			{
				query.Append($" {orderBy}");
			}

			if (limit.HasValue)
			{
				query.Append($" LIMIT {limit.Value}");
			}

			if (offset.HasValue)
			{
				query.Append($" OFFSET {offset.Value}");
			}

			return query.ToString();
		}

        public string GetColumnName<T>(string propertyName)
		{
			return PropertyToColumnName[$"{typeof(T).Name}.{propertyName}"];
		}

		public string GetFullTableName<T>()
		{
			return $"{TableSchemaName[typeof(T).Name]}.{ClassTableName[typeof(T).Name]}";
		}

		public QueryBuilder ClearTables()
		{
			selectColumns.Clear();
			fromTable = "";
			joins.Clear();
			query.Clear();
			isInitialized = false;
			return this;
		}

	}
}
