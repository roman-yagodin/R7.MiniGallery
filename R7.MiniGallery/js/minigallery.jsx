﻿class MiniGalleryImage extends React.Component {
    render() {
        return (
            <span className="MG_Item">
                <a href={this.props.EditUrl}>[edit]</a>
                <a href={this.props.Src} target="_blank" title={this.props.Title} className="MG_Link">
                    <img src={this.props.Src} alt={this.props.Alt} className="MG_Image" />
                </a>
            </span>
        );
    }
}

class BlueimpGalleryLightbox extends React.Component {
    render() {
        return (
            <div className="blueimp-gallery blueimp-gallery-controls">
                <div className="slides"></div>
                <h3 className="title"></h3>
                <a className="prev">&lt;</a>
                <a className="next">&gt;</a>
                <a className="close">&times;</a>
                <a className="play-pause"></a>
                <ol className="indicator"></ol>
            </div>
        );
    }
}

class BlueimpGallery extends React.Component {
    render() {
        return (
            <div className="MG_List">
                {this.props.Images.map((img) => <MiniGalleryImage Src={img.ImageSrc} Alt={img.Alt} Title={img.Title} EditUrl={img.EditUrl} />)}
            </div>
        );
    }
}

(function ($, window, document) {
    $(() => {
        ReactDOM.render(
            <BlueimpGalleryLightbox />, $(".minigallery-lightbox").get(0)
        );
        var container = $(".minigallery-lightbox .blueimp-gallery").get(0);
        $(".minigallery-inner").each ((i, m) => {
            var moduleId = $(m).data ("module-id");
            ReactDOM.render(
                <BlueimpGallery ModuleId={moduleId} Images={$(m).data ("images")} />, m
            );
            $("a.MG_Link").click ((event) => {
                var target = event.target || event.srcElement,
                link = target.src ? target.parentNode : target,
                options = {
                    hidePageScrollbars: false,
                    index: link,
                    event: event,
                    container: container
                };
                var links = $(target).closest(".minigallery-inner").find("a.MG_Link").get();
                blueimp.Gallery(links, options);
            });
        });
    });
}) (jQuery, window, document);