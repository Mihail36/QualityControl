import subprocess


def run_triangle_test(input_values, expected_result):
    result = subprocess.run(['python', 'triangle.py'] + input_values, capture_output=True, text=True, check=False)

    output = result.stdout.strip()
    status = 'success' if result.returncode == 0 and output == expected_result else 'error'
    return f"{status} -> [{' '.join(input_values)} | {expected_result}]"


def main():
    test_cases_file = 'test_cases.txt'
    output_file = 'results.txt'

    with open(test_cases_file, 'r', encoding='utf-8') as file:
        test_cases = [line.strip().split() for line in file if not line.startswith('#') and line.strip()]

    results = []
    for test_case in test_cases:
        input_values = test_case[:-1]
        expected_result = test_case[-1]
        result = run_triangle_test(input_values, expected_result)
        results.append(result)

    with open(output_file, 'w', encoding='utf-8') as file:
        file.write('\n'.join(results))


if __name__ == "__main__":
    main()