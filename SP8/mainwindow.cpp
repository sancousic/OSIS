#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QPair>


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

//draw
void MainWindow::on_pushButton_clicked()
{
    draw = true;
    repaint();
}

//clear
void MainWindow::on_pushButton_2_clicked()
{
    draw = false;
    repaint();
}

void MainWindow::paintEvent(QPaintEvent *)
{
    if(draw)
    {
        QPainter *paint = new QPainter(this);
        paint->setPen(QPen(Qt::black, 3, Qt::SolidLine));
        paint->setRenderHint(QPainter::Antialiasing, true);
        paint->setBrush(QBrush(Qt::white));
        paint->drawEllipse(120, 240, 120, 120);
        paint->drawEllipse(130, 140, 100, 100);
        paint->drawEllipse(140, 60, 80, 80);

        paint->setPen(QPen(Qt::black, 3, Qt::SolidLine));
        paint->setBrush(QBrush(Qt::black));
        paint->drawEllipse(178, 163, 4, 4);
        paint->drawEllipse(178, 183, 4, 4);
        paint->drawEllipse(178, 203, 4, 4);

        QRectF recta(165.0, 95.0, 30.0, 30.0);
        paint->drawArc(recta, 220*16, 100*16);

        paint->drawLine(80, 140, 145, 165);
        paint->drawLine(260, 140, 210, 165);

        QRectF rectangle(145.0, 20.0, 70.0, 70.0);
        int startAngle = 180 * 16;
        int spanAngle = 180 * 16;
        paint->setPen(QPen(Qt::blue, 0, Qt::SolidLine));
        paint->setBrush(QBrush(Qt::blue));
        paint->drawChord(rectangle, startAngle, spanAngle);

        static const QPointF points[4] = {
            QPointF(145.0, 65.0),
            QPointF(215.0, 65.0),
            QPointF(205, 0.0),
            QPointF(155.0, 0.0)
        };
        paint->drawConvexPolygon(points, 4);

        paint->setPen(QPen(Qt::cyan, 3, Qt::SolidLine));
        paint->setBrush(QBrush(Qt::cyan));
        paint->drawEllipse(160, 90, 4, 4);
        paint->drawEllipse(190, 90, 4, 4);

        paint->setPen(QPen(Qt::red, 3, Qt::SolidLine));
        paint->setBrush(QBrush(Qt::red));

        static const QPointF points1[3] = {
            QPointF(175.0, 95.0),
            QPointF(175.0, 105.0),
            QPointF(130.0, 102.5)
        };
        paint->drawConvexPolygon(points1, 3);
    }

}


