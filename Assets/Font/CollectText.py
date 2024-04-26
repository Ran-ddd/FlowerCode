import os

def merge_txt_files(folder_path, output_file):
    # 打开输出文件以写入模式
    with open(output_file, 'w', encoding='utf-8') as outfile:
        # 遍历文件夹中的所有文件
        for root, dirs, files in os.walk(folder_path):
            for file in files:
                # 如果文件是 .txt 文件
                if file.endswith('.txt'):
                    # 构建文件的完整路径
                    file_path = os.path.join(root, file)
                    # 打开文件并读取内容
                    with open(file_path, 'r', encoding='utf-8') as infile:
                        # 将文件内容写入到输出文件中
                        outfile.write(infile.read())
                        outfile.write('\n')  # 添加换行符分隔不同文件的内容

# 指定输入文件夹和输出文件路径
assets_folder = '../Resources/Text'
output_file = './AllText.txt'

# 合并所有 .txt 文件到一个新文件中
merge_txt_files(assets_folder, output_file)

print("合并完成！")
