from types import SimpleNamespace

def select(item, the_list):
    return map(lambda b: SimpleNamespace(item_a=item, item_b=b), the_list)


def left_outer_join(outer_list, inner_list):

    result = []
    for outer_item in outer_list:
        result.extend(select(outer_item, inner_list))
    return result


def select_many(outer_list, inner_item_list_key):
    result = []
    for outer_item in outer_list:
        result.extend(select(outer_item, getattr(outer_item, inner_item_list_key)))
    return result