#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_pushButton_clicked()
{
    QListWidget *list1 = ui->listWidget;
    QString str = ui->lineEdit->text();
    bool flag = true;
    for (int i = 0; i < list1->count(); i++)
    {
        QListWidgetItem *it = list1->item(i);
        if(str == it->text())
        {
            flag = false;
            break;
        }
    }
    if(flag) list1->addItem(str);
}

void MainWindow::on_pushButton_3_clicked()
{
    ui->listWidget->clear();
    ui->listWidget_2->clear();
}

void MainWindow::on_pushButton_2_clicked()
{
    if(ui->listWidget->currentItem() != nullptr)
    {
        ui->listWidget->removeItemWidget(ui->listWidget->currentItem());
        delete ui->listWidget->currentItem();
    }
    if(ui->listWidget_2->currentItem() != nullptr)
    {
        ui->listWidget_2->removeItemWidget(ui->listWidget_2->currentItem());
        delete ui->listWidget_2->currentItem();
    }
}

void MainWindow::on_pushButton_4_clicked()
{
    QListWidgetItem *currentItem = ui->listWidget->currentItem();
    bool flag = true;
    if(currentItem != nullptr)
    {
        for(int i = 0; i < ui->listWidget_2->count(); i++)
        {
            if(currentItem->text() == ui->listWidget_2->item(i)->text())
            {
                flag = false;
                break;
            }
        }
        if(flag) ui->listWidget_2->addItem(currentItem->text());
    }

}
