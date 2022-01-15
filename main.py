stack = []  # Array where operators contained
output = []

priority = {
    '*': 2,
    '/': 2,
    '+': 1,
    '-': 1
}


def infixToPrefix(data):
    data = Tokenization(data)
    print(data)
    for i in data:

        if i.isdigit():
            output.append(i)

        else:
            stack.append(i)

            if i == ')':  # Appending eac elem until we reach the "("
                while stack[-1] != '(':
                    e = stack.pop()
                    output.append(e)
                stack.pop()
                output.remove(')')

        if len(stack) != 0:
            for x in stack:

                try:
                    if priority[stack[-1]] <= priority[stack[-2]]:
                        output.append(stack[-2])
                        del stack[-2]
                except (IndexError, KeyError):
                    pass

    output.append(stack[-1])

    res = ' '.join(output)
    return res


def Tokenization(non_token):
    return list(non_token.replace(' ', ''))


print(infixToPrefix('5 * (10 - 8) / 7 + 1'))
