import sys


def get_triangle_type(a, b, c):
    if a + b <= c or a + c <= b or b + c <= a:
        return "Не треугольник"
    elif a == b == c:
        return "Равносторонний"
    elif a == b or b == c or a == c:
        return "Равнобедренный"
    else:
        return "Обычный"


def main():
    if len(sys.argv) != 4:
        print("Формат запуска: triangle.exe a b c")
        sys.exit(-1)

    try:
        a, b, c = map(float, sys.argv[1:])
    except ValueError:
        print("Входные данные должны быть числами")
        sys.exit(-1)

    result = get_triangle_type(a, b, c)
    print(result)


if __name__ == "__main__":
    main()