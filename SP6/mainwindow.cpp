#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    QCursor cursor = QCursor(QPixmap(":/recources/png/mouse.png"));
    this->setCursor(cursor);

    timer = new QTimer();
    connect(timer, SIGNAL(timeout()), this, SLOT(slotTimerAlarm()));
    timer->start(10);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_actionStart_triggered()
{
    if(first)
    {
        QFont font = label->font();
        font.setPointSize(14);
        font.setFamily("Times New Roman");
        x = this->width() / 2;
        y = this->height() / 2;
        label->move(x, y);
        label->show();
        first = false;
    }
    move = true;
}

void MainWindow::on_actionStop_triggered()
{
    move = false;
}

void MainWindow::slotTimerAlarm()
{
    if(move)
    {
        if(right)
        {
            if(label->x() + label->width() / 2 >= this->width())
            {
                right = false;
            }
            x += 10;

        }
        else
        {
            if(label->x() <= 0)
            {
                right = true;
            }
            x -= 10;
        }
        label->move(x, y);
    }

}
