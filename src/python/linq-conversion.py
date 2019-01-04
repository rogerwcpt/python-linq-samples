import shared


def linq54():
    doubles = [1.7, 2.3, 1.9, 4.1, 2.9]
  
    sorted_doubles = sorted(doubles, reverse=True)

    doubles_array = list(sorted_doubles)
  
    print("Every other double from highest to lowest:")
    d = 0
    while d < len(doubles_array):
        print(doubles_array[d])
        d += 2


def linq55():
    words = ["cherry", "apple", "blueberry"]

    sorted_words = sorted(words)

    word_list = list(sorted_words)

    print("The sorted word list:")
    shared.printN(word_list)


def linq56():
    score_records = [{'Name': "Alice", 'Score': 50},
                     {'Name': "Bob", 'Score': 40},
                     {'Name': "Cathy", 'Score': 45}]

    score_records_dict = {s['Name']:s['Score'] for s in score_records}

    print("Bob's score: %s" % score_records_dict["Bob"])


def linq57():
    numbers = [None, 1.0, "two", 3, "four", 5, "six", 7.0]

    floats = (n for n in numbers if isinstance(n, float))

    print("Numbers stored as floats:")
    shared.printN(floats)


linq54()
# linq55()
# linq56()
# linq57()
